using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KhotruyenM.Models;


namespace KhotruyenM.Controllers
{
    public class StoryController : Controller
    {
        ApplicationDbContext data = new ApplicationDbContext();
        //public ActionResult Phimbo()
        //{
        //    var phimbo = from s in data.stories.Where(n => n.CategoryId == "2")
        //                 select s;
        //    return View(phimbo);
        //}
        //public ActionResult Phimle()
        //{
        //    var phimle = from s in data.Films.Where(n => n.TypeFilm == "Phim lẻ")
        //                 select s;
        //    return View(phimle);
        //}
        //public ActionResult Phimchieurap()
        //{
        //    var phimchieurap = from s in data.Films.Where(n => n.TypeFilm == "Phim chiếu rạp")
        //                       select s;
        //    return View(phimchieurap);
        //}


        public ActionResult Home()
        {
            var home = from s in data.stories select s;
            return View(home);
        }

        public ActionResult Detail(int id)
        {
            var infos = data.stories.Where(n => n.StoryId == id).First();
            return View(infos);
        }

        public ActionResult SearchStory(string tensearch)
        {
            tensearch = tensearch.ToLower();
            var inf = data.stories.Where(n => n.vnName.ToLower().Contains(tensearch)
            || n.cnName.ToLower().Contains(tensearch) || n.Author.ToLower().Contains(tensearch));
            return View(inf.ToList());
        }
    }
}