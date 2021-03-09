using Quotex.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Quotex.DomainModels
{
    public class UserModel : BaseModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public ICollection<QuoteModel> Quotes { get; set; }
    }
}
