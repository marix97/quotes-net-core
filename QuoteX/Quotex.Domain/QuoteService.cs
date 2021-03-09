using Quotex.Domain.Interfaces;
using Quotex.DomainModels;
using Quotex.Entities;
using Quotex.Repositories;
using Quotex.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quotex.Domain
{
    public class QuoteService : BaseService<Quote, QuoteModel, IQuoteRepository>, IQuoteService
    {
        public QuoteService(IQuoteRepository quoteRepository) : base(quoteRepository) { }

        public async Task<bool> AddQuoteAsync(QuoteModel quote, string username)
        {
            return await _repository.AddQuoteFromUserAsync(quote, username);
        }

        public async Task<QuoteModel> DrawARandomQuoteAsync()
        {
            return await _repository.DrawAQuoteAsync();
        }

        public IQueryable<Quote> GetAllNotAcceptedQuotes()
        {
            return _repository.GetAllNotAcceptedQuotes();
        }

    }
}
