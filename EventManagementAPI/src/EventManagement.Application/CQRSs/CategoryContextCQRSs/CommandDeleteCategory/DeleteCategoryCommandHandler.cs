using EventManagement.Application.CQRSs.CategoryContextCQRSs.CommandCreateCategory;
using EventManagement.Domain.Constants;
using EventManagement.Domain.Entities.CategoryContextEntities;
using EventManagement.Domain.Exceptions;
using EventManagement.Domain.Repositories.CategoryContextRepositories;
using MediatR;

namespace EventManagement.Application.CQRSs.CategoryContextCQRSs.CommandDeleteCategory
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommandRequest, DeleteCategoryCommandResponse>
    {
        private readonly ICategoryRepository _categoryRepository;

        public DeleteCategoryCommandHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public Task<DeleteCategoryCommandResponse> Handle(DeleteCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            CategoryEntity categoryEntity = _categoryRepository.GetByID(request.ID) ?? throw new ClientSideException(ExceptionConstants.NotFoundCategory);
            _categoryRepository.Delete(categoryEntity);

            int effectedRows = _categoryRepository.SaveChanges();
            if (effectedRows == 0) return Task.FromResult(new DeleteCategoryCommandResponse(ResponseConstants.DeleteFailed));

            return Task.FromResult(new DeleteCategoryCommandResponse(ResponseConstants.SuccessfullyDeleted));
        }
    }
}
