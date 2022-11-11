

using ApartmentManagement.Application.Features.Managers.Models;
using ApartmentManagement.Application.Repositories.Abstract;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using NETCore.Encrypt;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace ApartmentManagement.Application.Features.Managers.Commands.ManagerLogin
{
    public class ManagerLoginCommand : IRequest<LoginModel>
    {
        [Required(ErrorMessage = "Boş Geçilemez")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Boş Geçilemez")]

        public string Password { get; set; }

        public string FullName { get; set; }
    }

    public class ManagerLoginCommandHandle : IRequestHandler<ManagerLoginCommand, LoginModel>
    {
        private readonly IManagerRepository repository;

        private readonly IMapper mapper;
        private readonly IHttpContextAccessor httpContextAccessor;
        

        public ManagerLoginCommandHandle(IManagerRepository repository, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.httpContextAccessor = httpContextAccessor;
        }
        public async Task<LoginModel> Handle(ManagerLoginCommand request, CancellationToken cancellationToken)
        {
            var model = mapper.Map<Domain.Entities.Manager>(request);
            var loginmodel = mapper.Map<LoginModel>(request);

            var modelHashedPassword = EncryptProvider.Md5(model.Password);
            loginmodel.Password = modelHashedPassword;
            repository.LoginManager(loginmodel);

            if (request != null)
            {
                var claims = new List<Claim>
                    {
                    
                    new Claim(ClaimTypes.Email,request.Email),

                    new Claim(ClaimTypes.Role,"Manager"),
                   };

                var fullname = repository.ManagerFullName();
                httpContextAccessor.HttpContext.Session.SetString("FullName", fullname);

                var claimsIdentity = new ClaimsIdentity(claims, "Login");
                var authProperties = new AuthenticationProperties();
                await httpContextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
               

            }
            return loginmodel;
        }
    }
}
