using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            using (GetTicketEntities db = new GetTicketEntities())
            {
                var concerts = db.Concerts;
                return View(concerts.ToList());
            }
                
        }
        public ActionResult Clasica()
        {
            using (GetTicketEntities db = new GetTicketEntities())
            {
                var concerts = db.Concerts;
                return View(concerts.ToList());
            }

        }
        public ActionResult Pop()
        {
            using (GetTicketEntities db = new GetTicketEntities())
            {
                var concerts = db.Concerts;
                return View(concerts.ToList());
            }

        }
        public ActionResult Rock()
        {
            using (GetTicketEntities db = new GetTicketEntities())
            {
                var concerts = db.Concerts;
                return View(concerts.ToList());
            }

        }
        public ActionResult Metal()
        {
            using (GetTicketEntities db = new GetTicketEntities())
            {
                var concerts = db.Concerts;
                return View(concerts.ToList());
            }

        }
        public ActionResult Reggae()
        {
            using (GetTicketEntities db = new GetTicketEntities())
            {
                var concerts = db.Concerts;
                return View(concerts.ToList());
            }

        }
        public ActionResult Electronica()
        {
            using (GetTicketEntities db = new GetTicketEntities())
            {
                var concerts = db.Concerts;
                return View(concerts.ToList());
            }

        }
        public ActionResult Fado()
        {
            using (GetTicketEntities db = new GetTicketEntities())
            {
                var concerts = db.Concerts;
                return View(concerts.ToList());
            }

        }
        public ActionResult HipHop()
        {
            using (GetTicketEntities db = new GetTicketEntities())
            {
                var concerts = db.Concerts;
                return View(concerts.ToList());
            }

        }
        public ActionResult Jazz()
        {
            using (GetTicketEntities db = new GetTicketEntities())
            {
                var concerts = db.Concerts;
                return View(concerts.ToList());
            }

        }
        public ActionResult Folk()
        {
            using (GetTicketEntities db = new GetTicketEntities())
            {
                var concerts = db.Concerts;
                return View(concerts.ToList());
            }

        }
        public ActionResult PopRock()
        {
            using (GetTicketEntities db = new GetTicketEntities())
            {
                var concerts = db.Concerts;
                return View(concerts.ToList());
            }

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
                    //user.LogInErrorMessage = "Wrong username or password";
                    ViewBag.ErrorMessage = "Wrong username or password";
                    return View("Login", user);
                }
                else
                {
                    Session["Id"] = user.Id;
                    return RedirectToAction("Index", "Home");
                }
            }
        
        }
        [HttpGet]
        public ActionResult NewUser(int id = 0)
        {
            Users user = new Users();
            return View(user);

        }
        [HttpPost]
        public ActionResult NewUser(Users user)
        {
            using (GetTicketEntities db = new GetTicketEntities())
            { 
                if (db.Users.Any(x => x.Username == user.Username))
                {
                    ViewBag.DuplicateMessage = "User Name Already Exists.";
                    return View("Register", user);
                }
                else
                {
                    while(db.Users.Any(x=>x.Id == user.Id))
                    {
                        user.Id++;
                    }
                    db.Users.Add(user);
                    db.SaveChanges();
                }

            }
            ModelState.Clear();
            ViewBag.SuccessMessage = "Registration successful.";
            return View("Register", new Users());
        }


    }
}