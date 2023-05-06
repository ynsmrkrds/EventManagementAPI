using MediatR;

namespace EventManagement.Application.CQRSs.CategoryContextCQRSs.CommandUpdateCategory
{
    public class UpdateCategoryCommandRequest : IRequest<UpdateCategoryCommandResponse>
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public UpdateCategoryCommandRequest(int id, string name)
        {
            ID = id;
            Name = name;
        }
    }
}
