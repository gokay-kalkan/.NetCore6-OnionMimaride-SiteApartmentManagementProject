using ApartmentManagement.Application.Features.Users.Commands.UserCreateCommand;
using ApartmentManagement.Application.Features.Users.Commands.UserDeleteCommand;
using ApartmentManagement.Application.Features.Users.Commands.UserUpdateCommand;
using ApartmentManagement.Application.Features.Users.Models;
using ApartmentManagement.Application.Features.Users.Queries.GetByIdUser;
using ApartmentManagement.Application.Features.Users.Queries.UserListQuery;
using ApartmentManagement.Application.Features.Users.ValidationRules;
using ApartmentManagement.Application.Repositories.Abstract;
using ApartmentManagement.Domain.Entities;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Generic;

namespace ApartmentManagement.UI.Areas.Manager.Controllers
{
    [Area("Manager")]
    [Authorize(Roles ="Manager")]
    public class UserController : BaseController
    {
        //private readonly IMediator Mediator;

        //public UserController(IMediator mediator)
        //{
        //    Mediator = mediator;
        //}

        public async Task<IActionResult> Index()
        {
            ListUserQuery listUserQuery = new ListUserQuery();
            var userList = await Mediator.Send(listUserQuery);
            return View(userList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
      
        public async Task<IActionResult> Create(CreateUserCommand createUserCommand)
        {
            UserValidationRule validationRules = new UserValidationRule();
            ValidationResult result = validationRules.Validate(createUserCommand);

            if (result.IsValid) {
                await Mediator.Send(createUserCommand);
                return RedirectToAction("Index");
            }
            return View(createUserCommand);
            

        }

        public async Task<IActionResult> Delete(int id)
        {
            DeleteUserCommand deleteUserCommand = new DeleteUserCommand { UserId = id };

            await Mediator.Send(deleteUserCommand);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int id)
        {
            var userGetByIdQueries = new UserGetByIdQueries { UserId = id };
            var UserModel= await Mediator.Send(userGetByIdQueries);
            return View(UserModel);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateUserCommand updateUserCommand)
        {
          
             await Mediator.Send(updateUserCommand);
            return RedirectToAction("Index");
        }

       
    }
}
