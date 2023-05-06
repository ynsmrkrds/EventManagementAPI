using MediatR;

namespace EventManagement.Application.CQRSs.LocationContextCQRSs.CommandCreateLocation
{
    public class CreateLocationCommandRequest : IRequest<CreateLocationCommandResponse>
    {
        public string Name { get; set; }

        public CreateLocationCommandRequest(string name)
        {
            Name = name;
        }
    }
}
