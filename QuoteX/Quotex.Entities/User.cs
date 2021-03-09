using System;
using System.Collections.Generic;
using System.Text;

namespace Quotex.Entities
{
    public class User : BaseEntity
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public ICollection<Quote> Quotes { get; set; }
    }
}
