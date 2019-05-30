using System.Linq;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Register()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public ActionResult Authorize(Models.Users user)
        {
            using (GetTicketEntities db = new GetTicketEntities())
            {
                var userDetails = db.Users.Where(i => i.Username == user.Username && i.Password == user.Password).FirstOrDefault();
                if (userDetails == null)
                {
                    user.LogInErrorMessage = "Wrong username or password";
                    return View("Login", user);
                }
                else
                {
                    Session["Id"] = user.Id;
                    return RedirectToAction("Index", "Home");
                }
            }
        
        }
        public ActionResult NewUser(int id = 0)
        {
            Users user = new Users();
            return View(user);

        }
        [HttpPost]
        public ActionResult NewUser(Users user)
        {
            using(GetTicketEntities db = new GetTicketEntities())
            {
               
                user.Id = 1;
                user.Wallet = 1000;
                db.Users.Add(user);
                db.SaveChanges();
             
             }
            ModelState.Clear();
            ViewBag.SuccessMessage = "Registration successful.";
            return View("Register", new Users());
        }
    }
}