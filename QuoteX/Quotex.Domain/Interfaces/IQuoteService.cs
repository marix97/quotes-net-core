using Quotex.DomainModels;
using Quotex.Entities;
using Quotex.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quotex.Domain.Interfaces
{
    public interface IQuoteService : IBaseService<Quote, QuoteModel, QuoteRepository>
    {
        Task<bool> AddQuoteAsync(QuoteModel quote, string username);
        IQueryable<Quote> GetAllNotAcceptedQuotes();

        Task<QuoteModel> DrawARandomQuoteAsync();
    }
}
