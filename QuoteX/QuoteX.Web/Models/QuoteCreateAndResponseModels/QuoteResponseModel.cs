using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuoteX.Web.Models.QuoteCreateAndResponseModels
{
    public class QuoteResponseModel
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public bool IsAcceptedByAdmin { get; set; }
    }
}
