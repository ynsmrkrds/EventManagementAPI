using MediatR;

namespace EventManagement.Application.CQRSs.TicketContextCQRSs.QueryGetAllTickets
{
    public class GetAllTicketCommandRequest : IRequest<GetAllTicketCommandResponse>
    {
    }
}
