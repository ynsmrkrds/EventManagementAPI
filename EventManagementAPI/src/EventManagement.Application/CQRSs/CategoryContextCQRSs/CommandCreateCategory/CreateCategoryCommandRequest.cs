using MediatR;

namespace EventManagement.Application.CQRSs.CategoryContextCQRSs.CommandCreateCategory
{
    public class CreateCategoryCommandRequest : IRequest<CreateCategoryCommandResponse>
    {
        public string Name { get; set; }

        public CreateCategoryCommandRequest(string name)
        {
            Name = name;
        }
    }
}
