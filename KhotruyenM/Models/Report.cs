using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KhotruyenM.Models
{
    public class Report
    {
        [Key]
        public long ReportId { get; set; }

        [Required]
        public string Content { get; set; }

        public DateTime CreateDate { get; set; }

        public long ChapterId { get; set; }

        public Chapter Chapter { get; set; }

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