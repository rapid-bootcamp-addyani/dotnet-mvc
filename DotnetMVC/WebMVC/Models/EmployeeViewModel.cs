namespace WebMVC.Models
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }
        public String EmployeeName { get; set; }
        public String Email { get; set; }
        public String Address { get; set; }
        public long Phone { get; set; }
        public String Position { get; set; }

        public EmployeeViewModel()
        {
        }

        public EmployeeViewModel(int id, string employeeName, string email, string address, long phone, string position)
        {
            Id = id;
            EmployeeName = employeeName;
            Email = email;
            Address = address;
            Phone = phone;
            Position = position;
        }
    }
}
