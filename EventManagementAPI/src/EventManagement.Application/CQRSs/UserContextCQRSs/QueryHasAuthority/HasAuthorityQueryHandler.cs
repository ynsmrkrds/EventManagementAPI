using EventManagement.Domain.Entities.UserContextEntities;
using EventManagement.Domain.Repositories.UserContextRepositories;
using MediatR;

namespace EventManagement.Application.CQRSs.UserContextCQRSs.QueryHasAuthority
{
    public class HasAuthorityQueryHandler : IRequestHandler<HasAuthorityQueryRequest, HasAuthorityQueryResponse>
    {
        private readonly IUserRoleRepository _userRoleRepository;
        private readonly IRoleRepository _roleRepository;

        public HasAuthorityQueryHandler(IUserRoleRepository userRoleRepository, IRoleRepository roleRepository)
        {
            _userRoleRepository = userRoleRepository;
            _roleRepository = roleRepository;
        }

        public Task<HasAuthorityQueryResponse> Handle(HasAuthorityQueryRequest request, CancellationToken cancellationToken)
        {
            foreach (string roleName in request.Roles)
            {
                RoleEntity? roleEntity = _roleRepository.GetByName(roleName);
                if (roleEntity == null) continue;

                UserRoleEntity? userRoleEntity = _userRoleRepository.GetByUserID(request.UserID);
                if (userRoleEntity == null) continue;

                if (userRoleEntity.RoleID == roleEntity.ID) return Task.FromResult(new HasAuthorityQueryResponse(true));
            }

            return Task.FromResult(new HasAuthorityQueryResponse(false));
        }
    }
}
