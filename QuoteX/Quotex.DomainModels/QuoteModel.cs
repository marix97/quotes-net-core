using System;
using System.Collections.Generic;
using System.Text;

namespace Quotex.DomainModels
{
    public class QuoteModel : BaseModel
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public bool IsAcceptedByAdmin { get; set; }
        public UserModel User { get; set; }
    }
}
