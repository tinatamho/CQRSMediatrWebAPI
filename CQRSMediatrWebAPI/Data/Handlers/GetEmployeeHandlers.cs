using CQRSMediatrWebAPI.Models;
using CQRSMediatrWebAPI.Services;
using MediatR;

namespace CQRSMediatrWebAPI.Data.Handlers
{
    public class GetEmployeeHandlers : IRequestHandler<GetEmployeeByIdQuery, Employee>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public GetEmployeeHandlers(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<Employee> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
        {
            return await _employeeRepository.GetEmployeeByIdAsync(request.Id);
        }
    }
}
