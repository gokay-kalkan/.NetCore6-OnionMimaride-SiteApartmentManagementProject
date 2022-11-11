using ApartmentManagement.Application.Features.Circles.Commands.CircleCreateCommand;
using ApartmentManagement.Application.Features.Circles.Commands.CircleDeleteCommand;
using ApartmentManagement.Application.Features.Circles.Commands.CircleUpdateCommand;
using ApartmentManagement.Application.Features.Circles.Models;
using ApartmentManagement.Application.Features.Circles.Queries.CircleListQuery;
using ApartmentManagement.Application.Features.Circles.Queries.GetByIdCircle;
using ApartmentManagement.Application.Features.Dues.Commands.DuesCreateCommand;
using ApartmentManagement.Application.Features.Dues.Commands.DuesDeleteCommand;
using ApartmentManagement.Application.Features.Dues.Commands.DuesUpdateCommand;
using ApartmentManagement.Application.Features.Dues.Queries.DuesListQuery;
using ApartmentManagement.Application.Features.Dues.Queries.GetByIdDues;
using ApartmentManagement.Application.Features.Users.Models;
using ApartmentManagement.Application.Features.Users.Queries.UserListQuery;
using ApartmentManagement.Application.Repositories.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ApartmentManagement.UI.Areas.Manager.Controllers
{
    [Area("Manager")]
    [Authorize(Roles ="Manager")]
    public class DuesController : BaseController
    {
        //ICircleRepository circleRepository;
      
        //public DuesController(ICircleRepository circleRepository)
        //{
        //    this.circleRepository = circleRepository;
           
        //}

        public async Task<IActionResult> Index()
        {
            ListDuesQuery listDuesQuery = new ListDuesQuery();
            var duesList = await Mediator.Send(listDuesQuery);
            
            return View(duesList);
        }


        public async Task<IActionResult> DelayedPayments()
        {
            ListDuesQuery listDuesQuery = new ListDuesQuery();
            var duesList = await Mediator.Send(listDuesQuery);

            var time = DateTime.Now;
            var userdues = duesList.Where(x=>x.PaymentDeadline < time).ToList();

            return View(userdues);


        }
        public async Task<IActionResult> UserGet(int CircleId)
        {
           
            ListCircleQuery listUserQuery = new ListCircleQuery();
            var circleList = await Mediator.Send(listUserQuery);
            List<CircleListModel> circleListUser = circleList.Where(x => x.CircleId == CircleId).ToList();
            List<SelectListItem> user = (from i in circleListUser
                                                    select new SelectListItem
                                                    {
                                                        Text = i.User.FullName,
                                                        Value = i.UserId.ToString()
                                                    }).ToList();
            ViewBag.user = user;
            return PartialView("UserGetPartial");

        }
        public PartialViewResult UserGetPartial()
        {
            return PartialView();
        }
        public async Task<IActionResult> Create()
        {
           
            await CircleListDropdown();
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Create(CreateDuesCommand createDuesCommand)
        {

            await Mediator.Send(createDuesCommand);


            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            DeleteDuesCommand deleteDuesCommand = new DeleteDuesCommand { DuesId = id };

            await Mediator.Send(deleteDuesCommand);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int id)
        {
            
            await CircleListDropdown();

            var duesGetByIdQueries = new GetByIdDuesQuery { DuesId = id };
            var duesModel = await Mediator.Send(duesGetByIdQueries);
            return View(duesModel);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateDuesCommand UpdateDuesCommand)
        {

            await Mediator.Send(UpdateDuesCommand);
            return RedirectToAction("Index");
        }

       

        public async Task<List<CircleListModel>> CircleListDropdown()
        {
            ListCircleQuery listUserQuery = new ListCircleQuery();
            var circleList = await Mediator.Send(listUserQuery);

            List<SelectListItem> circleListModel = (from i in circleList
                                                  select new SelectListItem
                                                  {
                                                      Text = i.CircleNo,
                                                      Value = i.CircleId.ToString()
                                                  }).ToList();
            ViewBag.circle = circleListModel;

            return circleList;
        }
    }
}
