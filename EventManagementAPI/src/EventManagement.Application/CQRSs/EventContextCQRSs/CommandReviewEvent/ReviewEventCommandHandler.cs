using AutoMapper;
using EventManagement.Application.CQRSs.EventContextCQRSs.CommandCancelEvent;
using EventManagement.Application.Helpers;
using EventManagement.Domain.Constants;
using EventManagement.Domain.Entities.EventContextEntities;
using EventManagement.Domain.Enums.CategoryContextEnums;
using EventManagement.Domain.Exceptions;
using EventManagement.Domain.Models;
using EventManagement.Domain.Repositories.EventContextRepositories;
using MediatR;

namespace EventManagement.Application.CQRSs.EventContextCQRSs.CommandReviewEvent
{
    public class ReviewEventCommandHandler : IRequestHandler<ReviewEventCommandRequest, ReviewEventCommandResponse>
    {
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;

        private static readonly List<EventStatus> reviewStatuses = new() { EventStatus.Approved, EventStatus.Canceled };

        public ReviewEventCommandHandler(IEventRepository eventRepository, IMapper mapper)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
        }

        public Task<ReviewEventCommandResponse> Handle(ReviewEventCommandRequest request, CancellationToken cancellationToken)
        {
            if (reviewStatuses.Contains(request.Status) == false) return Task.FromResult(new ReviewEventCommandResponse(ResponseConstants.UpdateFailed));

            EventEntity eventEntity = _eventRepository.GetByID(request.EventID) ?? throw new ClientSideException(ExceptionConstants.NotFoundEvent);

            if (DateTime.Now > eventEntity.Date) return Task.FromResult(new ReviewEventCommandResponse(ResponseConstants.UpdateFailed));

            _mapper.Map(request, eventEntity);
            _eventRepository.Update(eventEntity);

            int effectedRows = _eventRepository.SaveChanges();
            if (effectedRows == 0) return Task.FromResult(new ReviewEventCommandResponse(ResponseConstants.UpdateFailed));

            return Task.FromResult(new ReviewEventCommandResponse(ResponseConstants.SuccessfullyUpdated));
        }
    }
}
