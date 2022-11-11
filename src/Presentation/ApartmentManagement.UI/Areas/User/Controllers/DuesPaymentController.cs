using ApartmentManagement.Application.Features.Dues.Queries.DuesListQuery;
using ApartmentManagement.Application.Features.DuesPayments.Queries.DuesPaymentListQuery;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApartmentManagement.UI.Areas.User.Controllers
{
    [Area("User")]
    [Authorize(Roles ="User")]
    public class DuesPaymentController : BaseController
    {
        public async Task<IActionResult> Index()
        {
            ListDuesPaymentQuery listDuesQuery = new ListDuesPaymentQuery();
            var duesPaymentList = await Mediator.Send(listDuesQuery);
            var userpaymentdues = duesPaymentList.Where(x => x.UserId == HttpContext.Session.GetInt32("UserId")).ToList();
            return View(userpaymentdues);
        }

    }
}
