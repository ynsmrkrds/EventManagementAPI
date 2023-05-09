using EventManagement.Application.Helpers;
using EventManagement.Domain.Constants;
using EventManagement.Domain.Entities.EventContextEntities;
using EventManagement.Domain.Entities.TicketContextEntities;
using EventManagement.Domain.Enums.CategoryContextEnums;
using EventManagement.Domain.Exceptions;
using EventManagement.Domain.Models;
using EventManagement.Domain.Repositories.EventContextRepositories;
using EventManagement.Domain.Repositories.TicketContextRepositories;
using MediatR;

namespace EventManagement.Application.CQRSs.TicketContextCQRSs.CommandPurchaseTicket
{
    public class PurchaseTicketCommandHandler : IRequestHandler<PurchaseTicketCommandRequest, PurchaseTicketCommandResponse>
    {
        private readonly ITicketRepository _ticketRepository;
        private readonly IEventRepository _eventRepository;

        public PurchaseTicketCommandHandler(ITicketRepository ticketRepository, IEventRepository eventRepository)
        {
            _ticketRepository = ticketRepository;
            _eventRepository = eventRepository;
        }

        public Task<PurchaseTicketCommandResponse> Handle(PurchaseTicketCommandRequest request, CancellationToken cancellationToken)
        {
            TokenModel tokenModel = TokenHelper.Instance().DecodeTokenInRequest() ?? throw new ClientSideException(ExceptionConstants.TokenError);

            EventEntity eventEntity = _eventRepository.GetByID(request.EventID) ?? throw new ClientSideException(ExceptionConstants.NotFoundEvent);

            if (eventEntity.Status != EventStatus.Approved)
            {
                return Task.FromResult(new PurchaseTicketCommandResponse(ResponseConstants.EventNotActive));
            }

            if (eventEntity.CreatedByID == tokenModel.UserID)
            {
                return Task.FromResult(new PurchaseTicketCommandResponse(ResponseConstants.CannotBePurchasedOwnEventTicket));
            }

            if (_ticketRepository.HasTicket(eventEntity.ID, tokenModel.UserID))
            {
                return Task.FromResult(new PurchaseTicketCommandResponse(ResponseConstants.AlreadyHasTicket));
            }

            if (_ticketRepository.GetTicketCountOfEvent(request.EventID) >= eventEntity.Quota)
            {
                return Task.FromResult(new PurchaseTicketCommandResponse(ResponseConstants.ReachedEventQuota));
            }

            DateTime purchaseDate = DateTime.Now;
            string ticketNo = GenerateTicketNumber(tokenModel.UserID, eventEntity.ID, purchaseDate);

            TicketEntity ticketEntity = new(ticketNo, eventEntity.ID, purchaseDate, tokenModel.UserID);
            _ticketRepository.Add(ticketEntity);

            int effectedRows = _ticketRepository.SaveChanges();
            if (effectedRows == 0) return Task.FromResult(new PurchaseTicketCommandResponse(ResponseConstants.PurchaseFailed));

            return Task.FromResult(new PurchaseTicketCommandResponse(ResponseConstants.SuccessfullyPurchased));
        }

        private static string GenerateTicketNumber(int userID, int eventID, DateTime purchaseDate)
        {
            string dateInfo = purchaseDate.ToString("MMddyy");

            string userInfo = userID.ToString();
            string eventInfo = eventID.ToString();

            string ticketNumber = dateInfo + userInfo + eventInfo;

            return ticketNumber[^10..];
        }
    }
}
