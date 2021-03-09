using Quotex.DomainModels;
using Quotex.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quotex.Repositories.Interfaces
{
    public interface IQuoteRepository : IBaseRepository<Quote, QuoteModel>
    {
        Task<bool> AddQuoteFromUserAsync(QuoteModel quote, string username);
        IQueryable<Quote> GetAllNotAcceptedQuotes();

        Task<QuoteModel> DrawAQuoteAsync();
    }
}
