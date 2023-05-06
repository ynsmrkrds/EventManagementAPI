using MediatR;

namespace EventManagement.Application.CQRSs.CategoryContextCQRSs.CommandDeleteCategory
{
    public class DeleteCategoryCommandRequest : IRequest<DeleteCategoryCommandResponse>
    {
        public int ID { get; set; }

        public DeleteCategoryCommandRequest(int id)
        {
            ID = id;
        }
    }
}
