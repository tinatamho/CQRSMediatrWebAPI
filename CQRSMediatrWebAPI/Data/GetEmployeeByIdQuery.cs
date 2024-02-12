using CQRSMediatrWebAPI.Models;
using MediatR;

namespace CQRSMediatrWebAPI.Data
{
    public class GetEmployeeByIdQuery : IRequest<Employee>
    {
        public int Id { get; set; }
    }
}
