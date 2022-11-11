using ApartmentManagement.Application.Features.DuesPayments.Queries.DuesPaymentListQuery;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApartmentManagement.UI.Areas.Manager.Controllers
{
    [Area("Manager")]
    [Authorize(Roles ="Manager")]
    public class DuesPaymentController : BaseController
    {
        public async Task<IActionResult> Index()
        {
            ListDuesPaymentQuery listDuesQuery = new ListDuesPaymentQuery();
            var duesPaymentList = await Mediator.Send(listDuesQuery);
            
            return View(duesPaymentList);
        }
    }
}
