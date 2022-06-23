using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KhotruyenM.Models
{
    public class Chapter
    {
        [Key]
        public long ChapterId { get; set; }

        [Required]
        [StringLength(255)]
        public string ChapterNumber { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public int CountView { get; set; }

        [Required]
        public string Content { get; set; }

        public DateTime CreateDate { get; set; }

        public long StoryId { get; set; }

        public Story Story { get; set; }

        public Users Useries { get; set; }

        public void GetDateView()
        {
            if (CreateDate == null)
            {
                CreateDate = DateTime.Now;
            }
            if (CountView == null)
            {
                CountView = 0;
            }
        }
    }
}