using CQRSMediatrWebAPI.Data.Command;
using CQRSMediatrWebAPI.Services;
using MediatR;

namespace CQRSMediatrWebAPI.Data.Handlers
{
    public class DeleteEmployeeHandler : IRequestHandler<DeleteEmployeeCommand, int>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public DeleteEmployeeHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<int> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            var emp = await _employeeRepository.GetEmployeeByIdAsync(request.Id);
            if (emp == null) { return default; }
            return await _employeeRepository.DeleteEmployeeAsync(request.Id);
        }
    }
}
