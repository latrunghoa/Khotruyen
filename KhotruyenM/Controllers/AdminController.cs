using KhotruyenM.Models;
using System;
using PagedList;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KhotruyenM.Models.ViewModel;

namespace KhotruyenM.Controllers
{
    public class AdminController : Controller
    {
        ApplicationDbContext data = new ApplicationDbContext();
        // GET: User
        public ActionResult ControlStory(int? page)
        {
            if (page == null) page = 1;
            var story = (from s in data.stories
                        select s).OrderBy(n => n.StoryId);
            int pageSize = 5;
            int pageNum = page ?? 1;
            return View(story.ToPagedList(pageNum, pageSize));
        }
        public ActionResult ControlUser()
        {
            var us = from s in data.useries
                     select s;
            return View(us);
        }

        public ActionResult Home()
        {
            return View();
        }
        public ActionResult CreateStory()
        {
            SetViewType();
            return View();
        }
        public void SetViewType()
        {
            var ty = new Story();
            ViewBag.TypeStory = new SelectList(ty.ListAll(), "TypeStory", "TypeStory");
        }
        [HttpPost]
        public ActionResult CreateStory(Story stories, HttpPostedFileBase Upload)
        {
            if (!ModelState.IsValid)
            {
                return View("CreateStory");
            }
            var st = new Story
            {
                vnName = stories.vnName,
                cnName = stories.cnName,
                cnLink = stories.cnLink,
                Images = stories.Images,
                Author = stories.Author,
                TypeStory = stories.TypeStory,
                Information = stories.Information,
                CountView = stories.CountView,
                Rating = stories.Rating,
                CreateDate = DateTime.Now,
                UpdateDate = DateTime.Now
            };
            data.stories.Add(st);
            data.SaveChanges();
            return RedirectToAction("Home", "Admin");
        }

        public string ProcessUpload(HttpPostedFileBase file)
        {
            if (file == null)
            {
                return "";
            }
            file.SaveAs(Server.MapPath("~/Content/Images/Story/" + file.FileName));
            return "~/Content/Images/Story/" + file.FileName;
        }

        public ActionResult EditStory(int id)
        {
            var ed = data.stories.First(n => n.StoryId == id);
            return View(ed);
        }
        [HttpPost]
        public ActionResult EditStory(int id, FormCollection cls, HttpPostedFileBase Upload1)
        {
            var ed = data.stories.First(n => n.StoryId == id);
            ed.StoryId = id;
            var tenvn = cls["vnName"];
            var tentrung = cls["cnName"];
            var linkgoc = cls["cnLink"];
            var tacgia = cls["Author"];
            var anh = cls["Images"];
            var luotxem = Convert.ToInt32(cls["CountView"]);
            var danhgia = Convert.ToInt32(cls["Rating"]);
            var theloai = cls["TypeStory"];
            var noidung = cls["Information"];
            var ngaydang = Convert.ToDateTime(cls["CreateDate"]);
            var ngaycapnhat = Convert.ToDateTime(cls["UpdateDate"]);
            if (string.IsNullOrEmpty(tenvn))
            {
                ViewData["Error"] = "Có lỗi!!";
            }
            else
            {
                ed.vnName = tenvn.ToString();
                ed.cnName = tentrung.ToString();
                ed.Author = tacgia.ToString();
                ed.cnLink = linkgoc.ToString();
                ed.Images = anh.ToString();
                ed.Rating = danhgia;
                ed.CountView = luotxem;
                ed.TypeStory = theloai.ToString();
                ed.Information = noidung.ToString();
                ed.CreateDate = ngaydang;
                ed.UpdateDate = DateTime.Now;
                UpdateModel(ed);
                data.SaveChanges();
                return RedirectToAction("ControlStory");
            }
            return this.EditStory(id);
        }
        public string ProcessUpload1(HttpPostedFileBase file1)
        {
            if (file1 == null)
            {
                return "";
            }
            file1.SaveAs(Server.MapPath("~/Content/Images/Story/" + file1.FileName));
            return "/Content/Images/Story/" + file1.FileName;
        }
        public ActionResult DeleteStory(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Story sts = data.stories.Find(id);
            if (sts == null)
            {
                return HttpNotFound();
            }
            return View(sts);
        }
        [HttpPost, ActionName("DeleteStory")]
        public ActionResult DeleteStory(int id, FormCollection cls)
        {
            Story stss = data.stories.Find(id);
            data.stories.Remove(stss);
            data.SaveChanges();
            return RedirectToAction("ControlStory");
        }

        public ActionResult EditUser(int id)
        {
            var edu = data.useries.First(n => n.UserId == id);
            return View(edu);
        }
        [HttpPost]
        public ActionResult EditUser(int id, FormCollection cls, HttpPostedFileBase Upload2)
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
            return this.EditUser(id);
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
        public ActionResult DeleteUser(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Users us = data.useries.Find(id);
            if (us == null)
            {
                return HttpNotFound();
            }
            return View(us);
        }
        [HttpPost, ActionName("DeleteUser")]
        public ActionResult DeleteUseries(int id, FormCollection cls)
        {
            Users fmss = data.useries.Find(id);
            data.useries.Remove(fmss);
            data.SaveChanges();
            return RedirectToAction("ControlUser");
        }

        //public ActionResult SetTL()
        //{
        //    var vmc = new SetCategoriesViewModel
        //    {
        //        categories = data.categories.ToList(),
        //        stories = data.stories.ToList()
        //    };
        //    return View(vmc);
        //}
        //[HttpPost]
        //public ActionResult SetTL(int id, SetCategoriesViewModel cgviewmodel)
        //{
        //    var ed = data.categories.FirstOrDefault(n => n.StoryId == id);
        //    if (!ModelState.IsValid)
        //    {
        //        return View("CreateFilm");
        //    }
        //    var pp = new Category
        //    {
        //        StoryId = ed.StoryId,
        //        CategoryId = cgviewmodel.CategoryId,
        //    };
        //    data.categories.Add(pp);
        //    data.SaveChanges();
        //    return RedirectToAction("ControlPhim", "Admin");
        //}


        public ActionResult ControlChapter(int? page)
        {
            if (page == null) page = 1;
            var chapter = (from s in data.chapters
                         select s).OrderBy(n => n.ChapterId);
            int pageSize = 5;
            int pageNum = page ?? 1;
            return View(chapter.ToPagedList(pageNum, pageSize));
        }

        public ActionResult CreateChapter()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult CreateChapter(Chapter chapters)
        {
            if (!ModelState.IsValid)
            {
                return View("CreateChapter");
            }
            var ct = new Chapter
            {
                ChapterNumber = chapters.ChapterNumber,
                Name = chapters.Name,
                CountView = chapters.CountView,
                Content = chapters.Content,
                CreateDate = DateTime.Now,
                StoryName = chapters.StoryName
            };
            data.chapters.Add(ct);
            data.SaveChanges();
            return RedirectToAction("Home", "Admin");
        }

        public ActionResult EditChapter(int id)
        {
            var ed = data.chapters.First(n => n.ChapterId == id);
            return View(ed);
        }
        [HttpPost]
        public ActionResult EditChapter(int id, FormCollection cls)
        {
            var ed = data.chapters.First(n => n.ChapterId == id);
            ed.ChapterId = id;
            var sochuong = cls["ChapterNumber"];
            var tenchuong = cls["Name"];
            var luotxem = Convert.ToInt32(cls["CountView"]);
            var noidung = cls["Content"];
            var ngaydang = Convert.ToDateTime(cls["CreateDate"]);
            var thuoctruyen = Convert.ToInt32(cls["StoryName"]); ;
            if (string.IsNullOrEmpty(tenchuong))
            {
                ViewData["Error"] = "Có lỗi!!";
            }
            else
            {
                ed.ChapterNumber = sochuong.ToString();
                ed.Name = tenchuong.ToString();
                ed.CountView = luotxem;
                ed.Content = noidung.ToString();
                ed.CreateDate = ngaydang;
                ed.StoryName = thuoctruyen.ToString();
                UpdateModel(ed);
                data.SaveChanges();
                return RedirectToAction("ControlChapter");
            }
            return this.EditChapter(id);
        }

        public ActionResult DeleteChapter(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chapter cts = data.chapters.Find(id);
            if (cts == null)
            {
                return HttpNotFound();
            }
            return View(cts);
        }
        [HttpPost, ActionName("DeleteChapter")]
        public ActionResult DeleteChapter(int id, FormCollection cls)
        {
            Chapter ctss = data.chapters.Find(id);
            data.chapters.Remove(ctss);
            data.SaveChanges();
            return RedirectToAction("ControlChapter" +
                "");
        }
    }
}