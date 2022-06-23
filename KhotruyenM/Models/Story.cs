using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KhotruyenM.Models
{
    public class Story
    {
        [Key]
        public long StoryId { get; set; }

        [Required]
        public string vnName { get; set; }

        public string cnName { get; set; }

        public string cnLink { get; set; }

        public string Images { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        public string Information { get; set; }

        public int CountView { get; set; }

        public float Rating { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime UpdateDate { get; set; }

        public string TypeStory { get; set; }

        public Category Category { get; set; }

        public void PrePersist()
        {
            if (CreateDate == null)
            {
                CreateDate = DateTime.Now;
            }
            if (Rating == null)
            {
                Rating = (float)0;
            }
            if (CountView == null)
            {
                CountView = 0;
            }
            if (UpdateDate == null)
            {
                UpdateDate = DateTime.Now;
            }
        }

        ApplicationDbContext data = new ApplicationDbContext();
        public List<Story> ListAll()
        {
            return data.stories.Distinct().ToList();
        }

        public IEnumerable<Story> All()
        {
            return data.stories;
        }
    }
}