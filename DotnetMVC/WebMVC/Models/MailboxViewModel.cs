namespace WebMVC.Models
{
    public class MailboxViewModel
    {
        public int Id { get; set; }
        public String UserSending { get; set; }
        public String ToRecipients { get; set; }
        public String CCRecipients { get; set; }
        public String Subject { get; set; }
        public String Body { get; set; }
        public String Attachment { get; set; }
        public DateTime Scheduled { get; set; }
        public Boolean StatusDone { get; set; }

        public MailboxViewModel()
        {
        }

        public MailboxViewModel(int id, string userSending, string toRecipients, string cCRecipients, string subject, string body, string attachment, DateTime scheduled, bool statusDone)
        {
            Id = id;
            UserSending = userSending;
            ToRecipients = toRecipients;
            CCRecipients = cCRecipients;
            Subject = subject;
            Body = body;
            Attachment = attachment;
            Scheduled = scheduled;
            StatusDone = statusDone;
        }
    }
}
