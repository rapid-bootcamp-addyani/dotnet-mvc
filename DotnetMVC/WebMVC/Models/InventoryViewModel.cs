namespace WebMVC.Models
{
    public class InventoryViewModel
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Specification { get; set; }
        public int Quantity { get; set; }

        public int OnLoan { get; set; }

        public int Ready { get; set; }

        public InventoryViewModel()
        {
        }

        public InventoryViewModel(int id, string name, string specification, int quantity, int onLoan, int ready)
        {
            Id = id;
            Name = name;
            Specification = specification;
            Quantity = quantity;
            OnLoan = onLoan;
            Ready = ready;
        }
    }
}
