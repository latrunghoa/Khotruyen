using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KhotruyenM.Models
{
    public class Comment
    {
        [Key]
        public long CommentId { get; set; }

        [Required]
        public string Content { get; set; }

        public DateTime CreateDate { get; set; }

        public long StoryId { get; set; }

        public Story Story { get; set; }

        public Users Useries { get; set; }


        public void GetDateTime()
        {
            if (CreateDate == null)
            {
                CreateDate = DateTime.Now;
            }
        }
    }
}