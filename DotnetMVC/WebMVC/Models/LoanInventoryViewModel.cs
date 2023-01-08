namespace WebMVC.Models
{
    public class LoanInventoryViewModel
    {
        public int Id { get; set; }
        public String NameUser { get; set; }
        public String Admin { get; set; }
        public String Detail { get; set; }
        public Boolean Status { get; set; }
        public DateTime Date { get; set; }
        
        public LoanInventoryViewModel()
        {
        }

        public LoanInventoryViewModel(int id, string nameUser, string admin, string detail, bool status, DateTime date)
        {
            Id = id;
            NameUser = nameUser;
            Admin = admin;
            Detail = detail;
            Status = status;
            Date = date;
        }
    }
}
