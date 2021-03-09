using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Quotex.Domain.Interfaces;
using Quotex.DomainModels;
using QuoteX.Web.Models.RegisterAndLoginModels;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace QuoteX.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public AccountController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Register()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return View();
            }

            return Redirect("/Home/Index");
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel model, string captcha)
        {
            if (ModelState.IsValid)
            {
                var user = await _userService.GetUserByUsernameAsync(model.Username);

                if (user is null)
                {
                     var userModel = _mapper.Map<UserModel>(model);
                     userModel.Role = "User";

                     if (await _userService.AddAsync(userModel))
                     {
                        return Redirect("/Account/Login");
                     }

                    ModelState.AddModelError("", "Internal server error. User could not be added to database.");
                    return View(model);
                }

                ModelState.AddModelError("", "User with that username already exists.");
                return View(model);
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Login()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return View();
            }

            return Redirect("/Home/Index");
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userService.GetUserByUsernameAndPasswordAsync(model.Username, model.Password);

                if (!(user is null))
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, model.Username),
                        new Claim("FullName", model.Username),
                        new Claim(ClaimTypes.Role, user.Role),
                    };

                    var claimsIdentity = new ClaimsIdentity(
                        claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    var authProperties = new AuthenticationProperties
                    {

                        RedirectUri = "/Home/Index",

                    };

                    await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity),
                        authProperties);

                    return Redirect("/Home/Index");
                }

                ModelState.AddModelError("", "Username or password are incorrect.");
                return View(model);
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return Redirect("/Home/Index");
            }

            await HttpContext.SignOutAsync();
            return Redirect("/Home/Index");
        }

        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
