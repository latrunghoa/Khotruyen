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