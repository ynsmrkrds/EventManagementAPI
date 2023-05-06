namespace EventManagement.Application.ViewModels.CategoryContextViewModels
{
    public class CategoryViewModel : BaseViewModel
    {
        public string Name { get; set; }

        public CategoryViewModel(int id, DateTime createdDate, string name) : base(id, createdDate)
        {
            Name = name;
        }
    }
}
