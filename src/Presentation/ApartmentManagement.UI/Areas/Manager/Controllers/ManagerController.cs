using ApartmentManagement.Application.Repositories.Abstract;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using ApartmentManagement.UI.Areas.Manager.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using NETCore.Encrypt;
using ApartmentManagement.Persistence.Contexts;
using ApartmentManagement.Application.Features.Managers.Commands.ManagerLogin;

namespace ApartmentManagement.UI.Areas.Manager.Controllers
{
    [Area("Manager")]

    [Authorize(Roles = "Manager")]
    public class ManagerController : BaseController
    {


        private IUserRepository userRepository;
        private IMapper mapper;
        private DataContext context;
        
        public ManagerController(IUserRepository userRepository, IMapper mapper, DataContext context)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
            this.context = context;
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
        public async Task<IActionResult> Login(ManagerLoginCommand managerLoginCommand)
        {

            //var manager = mapper.Map<Domain.Entities.Manager>(model);


            //var modelHashedPassword = EncryptProvider.Md5(model.Password);

            //if (ModelState.IsValid)
            //{
            //    var dataValue = context.Managers.FirstOrDefault(x => x.Email == model.Email && x.Password == modelHashedPassword);
            //    if (dataValue !=null)
            //    {
            //        var claims = new List<Claim>
            //        {
            //        new Claim(ClaimTypes.Name,dataValue.FullName),
            //        new Claim(ClaimTypes.Email,dataValue.Email),
            //        new Claim(ClaimTypes.NameIdentifier,dataValue.ManagerId.ToString()),
            //        new Claim(ClaimTypes.Role,"Manager"),
            //       };

            //        HttpContext.Session.SetString("FullName", dataValue.FullName);

            //        var claimsIdentity = new ClaimsIdentity(claims, "Login");
            //        var authProperties = new AuthenticationProperties();
            //        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
            //        return RedirectToAction("Index");
            //    }
            //    ViewBag.errormessage = "Bilgileriniz uyuşmuyor kontrol ediniz";

            //    return View(model);

            //}
            await Mediator.Send(managerLoginCommand);
            return RedirectToAction("Index");


        }

        [AllowAnonymous]
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync();
            HttpContext.Session.Remove("FullName");
            return RedirectToAction("Login");
        }
    }
}
