using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ApartmentManagement.UI.Areas.Manager.Controllers
{
    public class BaseController : Controller
    {
        protected IMediator? Mediator => mediator ??= HttpContext.RequestServices.GetService<IMediator>();
        private IMediator? mediator;
    }
}
