using ApartmentManagement.Persistence.Contexts;
using ApartmentManagement.UI.Areas.Manager.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NETCore.Encrypt;
using System.Security.Claims;

namespace ApartmentManagement.UI.Areas.User.Controllers
{
    [Area("User")]
    [Authorize(Roles ="User")]
    public class UserController : Controller
    {
        private DataContext context;
        private IMapper mapper;

        public UserController(DataContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            var manager = mapper.Map<Domain.Entities.Manager>(model);


            var modelHashedPassword = EncryptProvider.Md5(model.Password);

            if (ModelState.IsValid)
            {
                var dataValue = context.Users.FirstOrDefault(x => x.Email == model.Email && x.Password == modelHashedPassword);
                if (dataValue != null)
                {
                    var claims = new List<Claim>
                    {
                    new Claim(ClaimTypes.Name,dataValue.FullName),
                    new Claim(ClaimTypes.Email,dataValue.Email),
                    new Claim(ClaimTypes.NameIdentifier,dataValue.UserId.ToString()),
                    new Claim(ClaimTypes.Role,"User"),
                   };

                    HttpContext.Session.SetString("FullName", dataValue.FullName);
                    HttpContext.Session.SetInt32("UserId", dataValue.UserId);


                    var claimsIdentity = new ClaimsIdentity(claims, "Login");
                    var authProperties = new AuthenticationProperties();
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
                    return RedirectToAction("Index");
                }
                ViewBag.errormessage = "Bilgileriniz uyuşmuyor kontrol ediniz";

                return View(model);

            }

            return View(model);
       
        }
        [AllowAnonymous]
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync();
            HttpContext.Session.Remove("FullName");
            HttpContext.Session.Remove("UserId");
            return RedirectToAction("Login");
        }

    }
}
