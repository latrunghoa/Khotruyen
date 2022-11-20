using KhotruyenM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KhotruyenM.Controllers
{
    public class ChapterController : Controller
    {
        ApplicationDbContext data = new ApplicationDbContext();
        // GET: Chapter

        public ActionResult DetailChapter(int id)
        {
            var infos = data.chapters.Where(n => n.ChapterId == id).First();
            return View(infos);
        }

        
    }
}