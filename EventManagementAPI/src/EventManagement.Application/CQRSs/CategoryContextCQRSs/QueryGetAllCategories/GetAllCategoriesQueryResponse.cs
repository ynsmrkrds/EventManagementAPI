using EventManagement.Application.ViewModels.CategoryContextViewModels;

namespace EventManagement.Application.CQRSs.CategoryContextCQRSs.QueryGetCategory
{
    public class GetAllCategoriesQueryResponse
    {
        public ICollection<CategoryViewModel> Categories { get; set; }

        public GetAllCategoriesQueryResponse(ICollection<CategoryViewModel> categories)
        {
            Categories = categories;
        }
    }
}
