using AutoMapper;
using EventManagement.Application.Helpers;
using EventManagement.Application.ViewModels.UserContextViewModels;
using EventManagement.Domain.Constants;
using EventManagement.Domain.Entities.UserContextEntities;
using EventManagement.Domain.Exceptions;
using EventManagement.Domain.Repositories.UserContextRepositories;
using MediatR;

namespace EventManagement.Application.CQRSs.UserContextCQRSs.QueryGetProfile
{
    public class GetProfileQueryHandler : IRequestHandler<GetProfileQueryRequest, GetProfileQueryResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetProfileQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public Task<GetProfileQueryResponse> Handle(GetProfileQueryRequest request, CancellationToken cancellationToken)
        {
            string? token = TokenHelper.Instance().GetTokenInRequest();
            if (string.IsNullOrEmpty(token)) throw new ClientSideException(ExceptionConstants.TokenError);

            int userID = TokenHelper.Instance().DecodeToken(token).UserID;

            UserEntity userEntity = _userRepository.GetByID(userID)!;
            UserViewModel userViewModel = _mapper.Map<UserViewModel>(userEntity);

            return Task.FromResult(new GetProfileQueryResponse(userViewModel));
        }
    }
}
