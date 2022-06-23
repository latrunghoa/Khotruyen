using KhotruyenM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KhotruyenM.Controllers
{
    public class UserController : Controller
    {
        ApplicationDbContext data = new ApplicationDbContext();

        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(Users useries)
        {
            if (!ModelState.IsValid)
            {
                return View("Register");
            }
            var check = data.useries.FirstOrDefault(u => u.UserName == useries.UserName);
            if (check == null)
            {
                var us = new Users
                {
                    UserName = useries.UserName,
                    Email = useries.Email,
                    Password = useries.Password,
                    DisplayName = useries.DisplayName,
                    Avatar = useries.Avatar,
                    CreateDate = DateTime.Now,
                    RoleID = 2
                };
                data.useries.Add(us);
                data.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.error = "Email đã đăng ký";
                return View();
            }
        }

        public string ProcessUpload(HttpPostedFileBase file)
        {
            if (file == null)
            {
                return "";
            }
            file.SaveAs(Server.MapPath("~/Content/Images/Avatar/" + file.FileName));
            return "/Content/Images/Avatar/" + file.FileName;
        }

        [HttpGet]
        public ActionResult Login()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection cls, Users useries)
        {
            var em = cls["Email"];
            var mk = cls["Password"];
            var ed = useries.RoleID;
            var check = data.useries.FirstOrDefault(n => n.Email == em && n.Password == mk);
            if (check != null)
            {
                if(check.RoleID == 1)
                {
                    Session["Taikhoan"] = check;
                    
                }
                else
                {
                    Session["Taikhoanadmin"] = check;
                }
                Session["Bietdanh"] = check.DisplayName;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Error = "Tài khoản không đúng hoặc chưa đăng ký";
                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}