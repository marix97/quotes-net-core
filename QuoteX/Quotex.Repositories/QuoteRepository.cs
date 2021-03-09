using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Quotex.DomainModels;
using Quotex.Entities;
using Quotex.Repositories.Interfaces;
using QuoteX.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quotex.Repositories
{
    public class QuoteRepository : BaseRepository<Quote, QuoteModel>, IQuoteRepository
    {
        public QuoteRepository(QuotexDBContext context, IMapper mapper) : base(context, mapper)
        {

        }

        public async Task<bool> AddQuoteFromUserAsync(QuoteModel quote, string username)
        {
            try
            {
                var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == username);

                var quoteEntity = _mapper.Map<Quote>(quote);
                quoteEntity.User = user;

                await _context.AddAsync(quoteEntity);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<QuoteModel> DrawAQuoteAsync()
        {
            Random rand = new Random();
            int toSkip = rand.Next(0, _context.Quotes.Where(q => q.IsAcceptedByAdmin).Count());

            var quote = await _context.Quotes.Where(q => q.IsAcceptedByAdmin).Skip(toSkip).Take(1).FirstAsync();

            return _mapper.Map<QuoteModel>(quote);
        }

        public IQueryable<Quote> GetAllNotAcceptedQuotes()
        {
            return _context.Quotes.AsNoTracking().Where(q => !q.IsAcceptedByAdmin).AsQueryable();
        }
    }
}
