using EventManagement.Application.Helpers;
using EventManagement.Domain.Constants;
using EventManagement.Domain.Entities.UserContextEntities;
using EventManagement.Domain.Exceptions;
using EventManagement.Domain.Repositories.UserContextRepositories;
using MediatR;

namespace EventManagement.Application.CQRSs.UserContextCQRSs.CommandUpdatePassword
{
    public class UpdatePasswordCommandHandler : IRequestHandler<UpdatePasswordCommandRequest, UpdatePasswordCommandResponse>
    {
        private readonly IUserRepository _userRepository;

        public UpdatePasswordCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<UpdatePasswordCommandResponse> Handle(UpdatePasswordCommandRequest request, CancellationToken cancellationToken)
        {
            string token = TokenHelper.Instance().GetTokenInRequest() ?? throw new ClientSideException(ExceptionConstants.TokenError);
            int userID = TokenHelper.Instance().DecodeToken(token).UserID;

            UserEntity userEntity = _userRepository.GetByID(userID) ?? throw new ClientSideException(ExceptionConstants.NotFoundUser);
            if (userEntity.PasswordHash != EncryptionHelper.Encrypt(request.CurrentPassword)) return Task.FromResult(new UpdatePasswordCommandResponse(ResponseConstants.CurrentPasswordIncorrect));

            userEntity.PasswordHash = EncryptionHelper.Encrypt(request.NewPassword);
            _userRepository.Update(userEntity);

            int effectedRows = _userRepository.SaveChanges();
            if (effectedRows == 0) return Task.FromResult(new UpdatePasswordCommandResponse(ResponseConstants.UpdateFailed));

            return Task.FromResult(new UpdatePasswordCommandResponse(ResponseConstants.SuccessfullyUpdated));
        }
    }
}
