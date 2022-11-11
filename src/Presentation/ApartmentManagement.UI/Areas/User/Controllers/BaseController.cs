using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ApartmentManagement.UI.Areas.User.Controllers
{
    public class BaseController : Controller
    {
        protected IMediator? Mediator => mediator ??= HttpContext.RequestServices.GetService<IMediator>();
        private IMediator? mediator;
    }
}
