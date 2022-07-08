using Application.Commands;
using Application.Mappers;
using Application.Queries;
using Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Employee.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IMediator _mediatR;
        public EmployeeController(IMediator mediatR)
        {
            _mediatR = mediatR;
        }

        [HttpGet]
        [ProducesResponseType(statusCode:200)]
        public async Task<List<Core.Entities.Employee>> Get()
        {
            var employees = await _mediatR.Send(new GetAllEmployeeQuery());
            return employees;
        }

        [HttpPost]
        [ProducesResponseType(statusCode:200)]
        public async Task<ActionResult<EmployeeResponse>> CreateEmployee([FromBody] CreateEmployeeCommand command)
        {
            var result = await _mediatR.Send(command);
            return Ok(result);
        }
    }
}
