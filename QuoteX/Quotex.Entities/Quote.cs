using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Quotex.Entities
{
    public class Quote : BaseEntity
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public bool IsAcceptedByAdmin { get; set; }
        public User User { get; set; }
    }
}
