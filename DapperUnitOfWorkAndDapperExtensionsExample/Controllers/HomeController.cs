using DapperUnitOfWorkAndDapperExtensionsExample.Models;
using DapperUnitOfWorkAndDapperExtensionsExample.Repositories;
using DapperUnitOfWorkAndDapperExtensionsExample.UnitsOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DapperUnitOfWorkAndDapperExtensionsExample.Controllers
{
    [ApiController]
    [Route("")]
    public class HomeController : ControllerBase
    {

        [HttpGet("")]
        public async Task<IEnumerable<Notifications>> Get([FromServices] INotificationRepository repository)
        {
            return await repository.GetList();
        }

        [HttpGet("count")]
        public async Task<int> Count([FromServices] INotificationRepository repository)
        {
            return await repository.GetCountAsync();
        }

        [HttpPost("")]
        public async Task<IActionResult> Post([FromServices] IUnitOfWork unitOfWork,
                                  [FromServices] INotificationRepository repository
                                 )
        {
            IActionResult actionResult = null;
            try
            {
                unitOfWork.Begin();
                var result = await repository.InsertAsync(new Notifications
                {
                    Date = DateTime.Now,
                    Title = "Teste " + DateTime.Now,
                    Url = "Teste " + DateTime.Now
                });

                unitOfWork.Commit();

                actionResult = Ok();
            }
            catch (Exception ex)
            {
                unitOfWork.Rollback();
                Console.WriteLine(ex);
                actionResult = new ObjectResult(ex.Message) { StatusCode = StatusCodes.Status500InternalServerError };
            }

            return actionResult;
        }

    }

}