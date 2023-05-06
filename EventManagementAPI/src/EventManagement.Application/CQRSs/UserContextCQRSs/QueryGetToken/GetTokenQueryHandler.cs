using EventManagement.Application.Helpers;
using EventManagement.Domain.Constants;
using EventManagement.Domain.Entities.UserContextEntities;
using EventManagement.Domain.Repositories.UserContextRepositories;
using MediatR;

namespace EventManagement.Application.CQRSs.UserContextCQRSs.QueryGetToken
{
    public class GetTokenQueryHandler : IRequestHandler<GetTokenQueryRequest, GetTokenQueryResponse>
    {
        private readonly IUserRepository _userRepository;

        public GetTokenQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<GetTokenQueryResponse> Handle(GetTokenQueryRequest request, CancellationToken cancellationToken)
        {
            string passwordHash = EncryptionHelper.Encrypt(request.Password);

            UserEntity? userEntity = _userRepository.ValidateUser(request.Email, passwordHash);
            if (userEntity == null) return Task.FromResult(new GetTokenQueryResponse(ResponseConstants.EmailOrPasswordIncorrect, null));

            string token = TokenHelper.Instance().CreateToken(userEntity);

            return Task.FromResult(new GetTokenQueryResponse(ResponseConstants.LoginSuccessful, token));
        }
    }
}
