using MediatR;

namespace EventManagement.Application.CQRSs.CategoryContextCQRSs.QueryGetCategory
{
    public class GetAllCategoriesQueryRequest : IRequest<GetAllCategoriesQueryResponse>
    {
    }
}
