using CQRSMediatrWebAPI.Models;
using MediatR;

namespace CQRSMediatrWebAPI.Data
{
    public class GetEmployeeListQuery : IRequest<List<Employee>>
    {
    }
}
