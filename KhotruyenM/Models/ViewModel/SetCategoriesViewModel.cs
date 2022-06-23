using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KhotruyenM.Models.ViewModel
{
    public class SetCategoriesViewModel
    {
        public int CategoryId { get; set; }
        public int StoryId { get; set; }
        public IEnumerable<Category> categories { get; set; }
        public IEnumerable<Story> stories { get; set; }
    }
}