using MediatR;

namespace EventManagement.Application.CQRSs.LocationContextCQRSs.CommandUpdateLocation
{
    public class UpdateLocationCommandRequest : IRequest<UpdateLocationCommandResponse>
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public UpdateLocationCommandRequest(int id, string name)
        {
            ID = id;
            Name = name;
        }
    }
}
