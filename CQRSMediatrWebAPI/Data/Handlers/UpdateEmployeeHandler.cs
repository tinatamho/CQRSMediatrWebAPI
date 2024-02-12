using CQRSMediatrWebAPI.Data.Command;
using CQRSMediatrWebAPI.Models;
using CQRSMediatrWebAPI.Services;
using MediatR;

namespace CQRSMediatrWebAPI.Data.Handlers
{
    public class UpdateEmployeeHandler : IRequestHandler<UpdateEmployeeCommand, int>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public UpdateEmployeeHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<int> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var emp = await _employeeRepository.GetEmployeeByIdAsync(request.Id);
            if (emp == null) { return default; }
            emp.Name = request.Name;
            emp.Email = request.Email;
            emp.Address = request.Address;
            emp.Phone = request.Phone;
            return await _employeeRepository.UpdateEmployeeAsync(emp);
        }
    }
}
