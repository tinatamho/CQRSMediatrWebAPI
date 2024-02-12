using CQRSMediatrWebAPI.Data;
using CQRSMediatrWebAPI.Data.Command;
using CQRSMediatrWebAPI.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CQRSMediatrWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private IMediator _mediator;

        public EmployeesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<EmployeesController>
        [HttpGet]
        public async Task<List<Employee>> EmployeeList()
        {
            var empList = await _mediator.Send(new GetEmployeeListQuery());
            return empList;
        }

        // GET api/<EmployeesController>/5
        [HttpGet("{id}")]
        public async Task<Employee> EmployeeByID(int id)
        {
            var emp = await _mediator.Send(new GetEmployeeByIdQuery() { Id = id });
            return emp;
        }

        // POST api/<EmployeesController>
        [HttpPost]
        public async Task<Employee> AddEmployee(Employee employee)
        {
            var emp = await _mediator.Send(new CreateEmployeeCommand(employee.Name, employee.Address, employee.Email, employee.Phone));
            return emp;
        }

        // PUT api/<EmployeesController>/5
        [HttpPut]
        public async Task<int> UpdateEmployee(Employee employee)
        {
            var emp = await _mediator.Send(new UpdateEmployeeCommand(employee.Id, employee.Name, employee.Address, employee.Email, employee.Phone));
            return emp;
        }

        // DELETE api/<EmployeesController>/5
        [HttpDelete("{id}")]
        public async Task<int> Delete(int id)
        {
            return await _mediator.Send(new DeleteEmployeeCommand() { Id = id });
        }
    }
}
