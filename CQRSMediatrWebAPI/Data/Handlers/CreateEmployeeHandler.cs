using CQRSMediatrWebAPI.Data.Command;
using CQRSMediatrWebAPI.Models;
using CQRSMediatrWebAPI.Services;
using MediatR;

namespace CQRSMediatrWebAPI.Data.Handlers
{
    public class CreateEmployeeHandler : IRequestHandler<CreateEmployeeCommand, Employee>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public CreateEmployeeHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<Employee> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            Employee emp = new Employee
            {
                Name = request.Name,
                Email = request.Email,
                Address = request.Address,
                Phone = request.Phone
            };

            return await _employeeRepository.AddEmployeeAsync(emp);
        }
    }
}
