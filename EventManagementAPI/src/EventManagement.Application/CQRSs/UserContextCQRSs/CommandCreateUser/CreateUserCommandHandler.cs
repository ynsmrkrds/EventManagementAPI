using AutoMapper;
using EventManagement.Application.Helpers;
using EventManagement.Domain.Constants;
using EventManagement.Domain.Entities.UserContextEntities;
using EventManagement.Domain.Repositories.UserContextRepositories;
using MediatR;

namespace EventManagement.Application.CQRSs.UserContextCQRSs.CommandCreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, CreateUserCommandResponse>
    {
        private const int defaultRoleID = 2; // standard user role

        private readonly IUserRepository _userRepository;
        private readonly IUserRoleRepository _userRoleRepository;
        private readonly IMapper _mapper;

        public CreateUserCommandHandler(IUserRepository userRepository, IUserRoleRepository userRoleRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _userRoleRepository = userRoleRepository;
            _mapper = mapper;
        }

        public Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {
            if (_userRepository.IsExistsWithSameEmail(request.Email)) return Task.FromResult(new CreateUserCommandResponse(ResponseConstants.ExistsUserWithSameEmail));

            UserEntity userEntity = _mapper.Map<UserEntity>(request);
            userEntity.PasswordHash = EncryptionHelper.Encrypt(request.Password);
            userEntity = _userRepository.Add(userEntity);

            int effectedRows = _userRepository.SaveChanges();
            if (effectedRows == 0) return Task.FromResult(new CreateUserCommandResponse(ResponseConstants.CreateFailed));

            UserRoleEntity userRoleEntity = new(userEntity.ID, defaultRoleID);
            _userRoleRepository.Add(userRoleEntity);

            effectedRows = _userRepository.SaveChanges();
            if (effectedRows == 0) return Task.FromResult(new CreateUserCommandResponse(ResponseConstants.CreateFailed));

            return Task.FromResult(new CreateUserCommandResponse(ResponseConstants.SuccessfullyCreated));
        }
    }
}
