using MediatR;

namespace CQRSMediatrWebAPI.Data.Command
{
    public class DeleteEmployeeCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
}
