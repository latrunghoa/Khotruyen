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
                return RedirectToAction("Home", "Story");
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
                return RedirectToAction("Home", "Story");
            }
            else
            {
                ViewBag.Error = "Tài khoản không đúng hoặc chưa đăng ký";
                return RedirectToAction("Home", "Story");
            }
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Home", "Story");
        }

        public ActionResult ChangeInformation(int id)
        {
            var edu = data.useries.First(n => n.UserId == id);
            return View(edu);
        }
        [HttpPost]
        public ActionResult ChangeInformation(int id, FormCollection cls, HttpPostedFileBase Upload2)
        {
            var ed = data.useries.First(n => n.UserId == id);
            ed.UserId = id;
            var tenvn = cls["UserName"];
            var matkhau = cls["Password"];
            var bietdanh = cls["DisplayName"];
            var email = cls["Email"];
            var anh = cls["Avatar"];
            var ngaytao = Convert.ToDateTime(cls["CreateDate"]);
            var idr = cls["RoleId"];
            if (string.IsNullOrEmpty(tenvn))
            {
                ViewData["Error"] = "Có lỗi!!";
            }
            else
            {
                ed.UserName = tenvn.ToString();
                ed.Password = matkhau.ToString();
                ed.DisplayName = bietdanh.ToString();
                ed.Email = email.ToString();
                ed.Avatar = anh.ToString();
                ed.CreateDate = ngaytao;
                ed.RoleID = int.Parse(idr);
                UpdateModel(ed);
                data.SaveChanges();
                return RedirectToAction("ControlUser");
            }
            return this.ChangeInformation(id);
        }
        public string ProcessUpload2(HttpPostedFileBase file2)
        {
            if (file2 == null)
            {
                return "";
            }
            file2.SaveAs(Server.MapPath("~/Content/Images/Avatar/" + file2.FileName));
            return "/Content/Images/Avatar/" + file2.FileName;
        }
    }
}