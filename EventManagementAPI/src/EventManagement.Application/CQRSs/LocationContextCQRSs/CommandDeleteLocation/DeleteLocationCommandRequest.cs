using MediatR;

namespace EventManagement.Application.CQRSs.LocationContextCQRSs.CommandDeleteLocation
{
    public class DeleteLocationCommandRequest : IRequest<DeleteLocationCommandResponse>
    {
        public int ID { get; set; }

        public DeleteLocationCommandRequest(int id)
        {
            ID = id;
        }
    }
}
