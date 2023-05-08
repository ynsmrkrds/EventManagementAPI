using AutoMapper;
using EventManagement.Application.Helpers;
using EventManagement.Application.ViewModels.EventContextViewModels;
using EventManagement.Domain.Constants;
using EventManagement.Domain.Entities.EventContextEntities;
using EventManagement.Domain.Exceptions;
using EventManagement.Domain.Models;
using EventManagement.Domain.Repositories.EventContextRepositories;
using MediatR;

namespace EventManagement.Application.CQRSs.EventContextCQRSs.QueryGetAllEvents
{
    public class GetAllEventsQueryHandler : IRequestHandler<GetAllEventsQueryRequest, GetAllEventsQueryResponse>
    {
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;

        public GetAllEventsQueryHandler(IEventRepository eventRepository, IMapper mapper)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
        }

        public Task<GetAllEventsQueryResponse> Handle(GetAllEventsQueryRequest request, CancellationToken cancellationToken)
        {
            List<EventEntity> events = _eventRepository.GetAll().ToList();

            List<EventViewModel> viewModels = _mapper.Map<List<EventEntity>, List<EventViewModel>>(events);

            return Task.FromResult(new GetAllEventsQueryResponse(viewModels));
        }
    }
}
