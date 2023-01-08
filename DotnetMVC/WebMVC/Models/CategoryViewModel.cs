namespace WebMVC.Models
{
    public class CategoryViewModel
    {
        public int Id { get; set; }
        public String Name { get; set; }

        public CategoryViewModel()
        {
        }

        public CategoryViewModel(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
