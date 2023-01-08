using Microsoft.AspNetCore.Mvc;
using WebMVC.Models;

namespace WebMVC.Controllers
{
    //int id, string userSending, string toRecipients, string cCRecipients, string subject, string body, string attachment, DateTime scheduled, bool statusDone
    public class MailboxController : Controller
    {
        private static List<MailboxViewModel> _mailboxViewModels = new List<MailboxViewModel>()
        {
            new MailboxViewModel(1, "addyani@gmail.com", "amirul@gmail.com,fajar@gmail.com,malik@gmail.com", "test@gmail.com", "ini subject", "ini body", "file.doc,video.mp4", DateTime.Now.AddMinutes(-30), true),
            new MailboxViewModel(2, "andi@gmail.com", "amirul@gmail.com,fajar@gmail.com,malik@gmail.com", "test@gmail.com", "ini subject", "ini body", "file.doc,video.mp4", DateTime.Now.AddMinutes(30), false),
            new MailboxViewModel(3, "dian@gmail.com", "amirul@gmail.com,fajar@gmail.com,malik@gmail.com", "test@gmail.com", "ini subject", "ini body", "file.doc,video.mp4", DateTime.Now.AddMinutes(-10), true),
        };

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Add()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Save([Bind("Id, UserSending, ToRecipients, CCRecipients, Subject, Body, Attachment, Scheduled, StatusDone")] MailboxViewModel mailbox)
        {
            _mailboxViewModels.Add(mailbox);
            return Redirect("List");
        }

        public IActionResult List()
        {
            return View(_mailboxViewModels);
        }

        public IActionResult Edit(int? id)
        {
            MailboxViewModel mailbox = _mailboxViewModels.Find(x => x.Id.Equals(id));
            return View(mailbox);
        }

        [HttpPost]
        public IActionResult Update(int id, [Bind("Id, UserSending, ToRecipients, CCRecipients, Subject, Body, Attachment, Scheduled, StatusDone")] MailboxViewModel mailbox)
        {
            MailboxViewModel mailboxOld = _mailboxViewModels.Find(x => x.Id.Equals(id));
            _mailboxViewModels.Remove(mailboxOld);

            _mailboxViewModels.Add(mailbox);
            return Redirect("List");
        }

        public IActionResult Details(int id)
        {
            MailboxViewModel mailbox = (
                    from p in _mailboxViewModels
                    where p.Id.Equals(id)
                    select p
                ).SingleOrDefault(new MailboxViewModel());
            return View(mailbox);
        }

        public IActionResult Delete(int? id)
        {
            MailboxViewModel mailbox = _mailboxViewModels.Find(x => x.Id.Equals(id));
            _mailboxViewModels.Remove(mailbox);

            return Redirect("/Mailbox/List");
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create([Bind("Id, UserSending, ToRecipients, CCRecipients, Subject, Body, Attachment, Scheduled, StatusDone")] MailboxViewModel mailbox)
        {
            _mailboxViewModels.Add(mailbox);
            return Redirect("List");
        }
    }
}
