using System.ComponentModel.DataAnnotations;

namespace QuoteX.Web.Models.RegisterAndLoginModels
{
    public class LoginModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
