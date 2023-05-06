using AutoMapper;
using EventManagement.Domain.Constants;
using EventManagement.Domain.Entities.CategoryContextEntities;
using EventManagement.Domain.Repositories.CategoryContextRepositories;
using MediatR;

namespace EventManagement.Application.CQRSs.CategoryContextCQRSs.CommandCreateCategory
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommandRequest, CreateCategoryCommandResponse>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CreateCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public Task<CreateCategoryCommandResponse> Handle(CreateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            if (_categoryRepository.IsExistsWithSameName(request.Name)) return Task.FromResult(new CreateCategoryCommandResponse(ResponseConstants.ExistsCategoryWithSameName));

            CategoryEntity categoryEntity = _mapper.Map<CreateCategoryCommandRequest, CategoryEntity>(request);
            _categoryRepository.Add(categoryEntity);

            int effectedRows = _categoryRepository.SaveChanges();
            if (effectedRows == 0) return Task.FromResult(new CreateCategoryCommandResponse(ResponseConstants.CreateFailed));

            return Task.FromResult(new CreateCategoryCommandResponse(ResponseConstants.SuccessfullyCreated));
        }
    }
}
