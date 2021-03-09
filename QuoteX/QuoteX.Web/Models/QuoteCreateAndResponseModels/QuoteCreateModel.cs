using Quotex.DomainModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuoteX.Web.Models.QuoteCreateAndResponseModels
{
    public class QuoteCreateModel
    {
        [Required]
        [StringLength(256, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 3)]
        public string QuoteText { get; set; }
    }
}
