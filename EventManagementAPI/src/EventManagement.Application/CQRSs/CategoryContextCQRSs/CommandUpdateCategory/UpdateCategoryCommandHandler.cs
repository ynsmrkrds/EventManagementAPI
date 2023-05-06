using AutoMapper;
using EventManagement.Domain.Constants;
using EventManagement.Domain.Entities.CategoryContextEntities;
using EventManagement.Domain.Exceptions;
using EventManagement.Domain.Repositories.CategoryContextRepositories;
using MediatR;

namespace EventManagement.Application.CQRSs.CategoryContextCQRSs.CommandUpdateCategory
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommandRequest, UpdateCategoryCommandResponse>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public UpdateCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public Task<UpdateCategoryCommandResponse> Handle(UpdateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            CategoryEntity categoryEntity = _categoryRepository.GetByID(request.ID) ?? throw new ClientSideException(ExceptionConstants.NotFoundCategory);

            _mapper.Map(request, categoryEntity);
            _categoryRepository.Update(categoryEntity);

            int effectedRows = _categoryRepository.SaveChanges();
            if (effectedRows == 0) return Task.FromResult(new UpdateCategoryCommandResponse(ResponseConstants.UpdateFailed));

            return Task.FromResult(new UpdateCategoryCommandResponse(ResponseConstants.SuccessfullyUpdated));
        }
    }
}
