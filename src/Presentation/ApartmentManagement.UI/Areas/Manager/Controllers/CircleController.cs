using ApartmentManagement.Application.Features.Circles.Commands.CircleCreateCommand;
using ApartmentManagement.Application.Features.Circles.Commands.CircleDeleteCommand;
using ApartmentManagement.Application.Features.Circles.Commands.CircleUpdateCommand;
using ApartmentManagement.Application.Features.Circles.Queries.CircleListQuery;
using ApartmentManagement.Application.Features.Circles.Queries.GetByIdCircle;
using ApartmentManagement.Application.Features.Users.Commands.UserCreateCommand;
using ApartmentManagement.Application.Features.Users.Commands.UserDeleteCommand;
using ApartmentManagement.Application.Features.Users.Commands.UserUpdateCommand;
using ApartmentManagement.Application.Features.Users.Models;
using ApartmentManagement.Application.Features.Users.Queries.GetByIdUser;
using ApartmentManagement.Application.Features.Users.Queries.UserListQuery;
using ApartmentManagement.Application.Repositories.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;

namespace ApartmentManagement.UI.Areas.Manager.Controllers
{
    [Area("Manager")]
    [Authorize(Roles = "Manager")]
    public class CircleController : BaseController
    {
      
        public async Task<IActionResult> Index()
        {
            ListCircleQuery listCircleQuery = new ListCircleQuery();
            var circleList = await Mediator.Send(listCircleQuery);
            return View(circleList);
        }

        public async Task<IActionResult> Create()
        {
             await UserListDropdown();
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Create(CreateCircleCommand createCircleCommand)
        {

            await Mediator.Send(createCircleCommand);

      
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            DeleteCircleCommand deleteCircleCommand = new DeleteCircleCommand { CircleId = id };

            await Mediator.Send(deleteCircleCommand);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int id)
        {
            await UserListDropdown();

            var circleGetByIdQueries = new GetByIdCircleQuery { CircleId = id };
            var circleModel = await Mediator.Send(circleGetByIdQueries);
            return View(circleModel);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateCircleCommand UpdateCircleCommand)
        {

            await Mediator.Send(UpdateCircleCommand);
            return RedirectToAction("Index");
        }

        public  async Task<List<UserListModel>> UserListDropdown()
        {
            ListUserQuery listUserQuery = new ListUserQuery();
            var userList = await Mediator.Send(listUserQuery);

            List<SelectListItem> userListModel = (from i in userList
                                             select new SelectListItem
                                           {
                                               Text = i.FullName,
                                               Value = i.UserId.ToString()
                                           }).ToList();
            ViewBag.users = userListModel;

            return userList;
        }
    }
}
