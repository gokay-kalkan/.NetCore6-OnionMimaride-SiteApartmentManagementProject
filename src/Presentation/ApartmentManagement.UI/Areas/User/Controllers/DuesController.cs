
using ApartmentManagement.Application.Features.Dues.Commands.DuesPaidStatusUpdateCommand;
using ApartmentManagement.Application.Features.Dues.Commands.DuesUpdateCommand;
using ApartmentManagement.Application.Features.Dues.Models;
using ApartmentManagement.Application.Features.Dues.Queries.DuesListQuery;
using ApartmentManagement.Application.Features.Dues.Queries.GetByIdDues;
using ApartmentManagement.Application.Features.DuesPayments.Commands.DuesPaymentCreateCommand;
using ApartmentManagement.Application.Features.DuesPayments.Models;
using ApartmentManagement.Application.Features.DuesPayments.Queries.DuesPaymentListQuery;
using ApartmentManagement.Domain.Entities;
using ApartmentManagement.Infrastructure.Services.RabbitMq;
using ApartmentManagement.Persistence.Contexts;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration.UserSecrets;
using RabbitMQ.Client;
using System.Data;
using System.Net.Mail;
using System.Text;

namespace ApartmentManagement.UI.Areas.User.Controllers
{
    [Area("User")]
    [Authorize(Roles = "User")]
    public class DuesController : BaseController
    {

        public async Task<IActionResult> Index()
        {
            ListDuesQuery listDuesQuery = new ListDuesQuery();
            var duesList = await Mediator.Send(listDuesQuery);
            var userdues = duesList.Where(x => x.UserId == HttpContext.Session.GetInt32("UserId")).ToList();
            return View(userdues);
        }

        public IActionResult DuesPaid(int id)
        {
            ViewBag.duesId = id;
         

            ViewBag.userid = HttpContext.Session.GetInt32("UserId");
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> DuesPaid(CreateDuesPaymentCommand createDuesPaymentCommand)
        {


            await Mediator.Send(createDuesPaymentCommand);

            

            ListDuesQuery listDuesQuery = new ListDuesQuery();

            var duesList = await Mediator.Send(listDuesQuery);

            var userdues = duesList.Where(x => x.UserId == HttpContext.Session.GetInt32("UserId")).ToList();
            var usermail = userdues.Where(x => x.UserId == HttpContext.Session.GetInt32("UserId")).Select(x => x.User.Email).First();

            var datas = Encoding.UTF8.GetBytes(usermail);

            SetQueues.SetQueue(datas);  //rabbit mq kuyruğa mesaj gönderildi.


            var duesId = userdues.Select(x => x.DuesId).FirstOrDefault();
            var duesPaymentDate = userdues.Select(x => x.PaymentDate).FirstOrDefault();
            var duesPrice = userdues.Select(x => x.DuesPrice).FirstOrDefault();
            var paymentDeadline = userdues.Select(x => x.PaymentDeadline).FirstOrDefault();

            GetByIdDuesQuery getByIdDuesQuery = new() { DuesId = duesId };
            var duesmodel = await Mediator.Send(getByIdDuesQuery);


            UpdateDuesPaidStatusCommand updateDuesPaidStatusCommand = new();
            updateDuesPaidStatusCommand.DuesId = duesmodel.DuesId;
            updateDuesPaidStatusCommand.CircleId = duesmodel.CircleId;
            updateDuesPaidStatusCommand.UserId = HttpContext.Session.GetInt32("UserId");
            updateDuesPaidStatusCommand.DuesPrice = duesmodel.DuesPrice;
            updateDuesPaidStatusCommand.PaymentDate = duesmodel.PaymentDate;
            updateDuesPaidStatusCommand.DuesType = duesmodel.DuesType;
            updateDuesPaidStatusCommand.PaidStatus = true;
           
            updateDuesPaidStatusCommand.PaymentDeadline = duesmodel.PaymentDeadline;
            await Mediator.Send(updateDuesPaidStatusCommand);


            ListDuesPaymentQuery listDuesPaymentQuery = new ListDuesPaymentQuery();

            var duesPaymentListModel = await Mediator.Send(listDuesPaymentQuery);

            var duesPaymentListUser = duesPaymentListModel.Where(x => x.UserId == HttpContext.Session.GetInt32("UserId")).ToList();

            var duesPaymentPaymentDate = duesPaymentListUser.Select(x => x.PaymentDate).FirstOrDefault();


           

            return RedirectToAction("Index", "DuesPayment", new { area = "User" });

            
        }
       

        public async Task<IActionResult> DelayedPayments()
        {
            ListDuesQuery listDuesQuery = new ListDuesQuery();
            var duesList = await Mediator.Send(listDuesQuery);

           var time= DateTime.Now;
            var userdues = duesList.Where(x => x.UserId == HttpContext.Session.GetInt32("UserId") && x.PaymentDeadline<time).ToList();
          
            return View(userdues);
           

               
        }
    }
}
