using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Quotex.Domain.Interfaces;
using Quotex.DomainModels;
using QuoteX.Web.Models.QuoteCreateAndResponseModels;
using System.Threading.Tasks;
using X.PagedList;

namespace QuoteX.Web.Controllers
{
    [Authorize]
    public class QuoteController : Controller
    {
        private IQuoteService _quoteService;
        private IMapper _mapper;

        public QuoteController(IQuoteService quoteService, IMapper mapper)
        {
            _quoteService = quoteService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> CreateQuote()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateQuote([FromBody]string quoteText)
        {
            //Create the model and set isAcceptedByAdmin to false so an admin can review the quote posted
            QuoteModel quoteModel = new QuoteModel();
            quoteModel.Text = quoteText;
            quoteModel.IsAcceptedByAdmin = false;

            var isAdded = await _quoteService.AddQuoteAsync(quoteModel, User.Identity.Name);

            if (isAdded)
            {
                return Created($"Quote/CreateQuote", quoteModel);            
            }

            //In case the quote wasn't added to the database we need to notify the user
            return StatusCode(500, "Quote could not be added to database.");
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult GetQuotes(int? page)
        {
            var quotes = _quoteService.GetAllNotAcceptedQuotes();

            var pageNumber = page ?? 1;

            if (page <= 0)
            {
                //If page number is 0 or less than 0
                pageNumber = 1;
            }

            var onePage = quotes.ToPagedList(pageNumber, 10);
            ViewBag.OnePageOfQuotes = onePage;

            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> RemoveQuote(int id)
        {
            await _quoteService.DeleteAsync(id);
            return Ok();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> ApproveQuote(int id)
        {
            var quote = await _quoteService.GetByIdIfExistsAsync(id);
            quote.IsAcceptedByAdmin = true;

            await _quoteService.UpdateAsync(id, quote);

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> DrawQuote()
        {
            var quote = await _quoteService.DrawARandomQuoteAsync();

            return Ok(_mapper.Map<QuoteResponseModel>(quote));
        }
    }
}
