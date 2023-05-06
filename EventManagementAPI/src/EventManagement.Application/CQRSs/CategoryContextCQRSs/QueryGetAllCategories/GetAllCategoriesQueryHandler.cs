using AutoMapper;
using EventManagement.Application.ViewModels.CategoryContextViewModels;
using EventManagement.Domain.Entities.CategoryContextEntities;
using EventManagement.Domain.Repositories.CategoryContextRepositories;
using MediatR;

namespace EventManagement.Application.CQRSs.CategoryContextCQRSs.QueryGetCategory
{
    public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQueryRequest, GetAllCategoriesQueryResponse>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public GetAllCategoriesQueryHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public Task<GetAllCategoriesQueryResponse> Handle(GetAllCategoriesQueryRequest request, CancellationToken cancellationToken)
        {
            List<CategoryEntity> categories = _categoryRepository.GetAll().ToList();

            List<CategoryViewModel> viewModels = _mapper.Map<List<CategoryEntity>, List<CategoryViewModel>>(categories);

            return Task.FromResult(new GetAllCategoriesQueryResponse(viewModels));
        }
    }
}
