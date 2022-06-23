using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KhotruyenM.Models
{
    public class History
    {
        [Key]
        public long HistoryId { get; set; }

        [StringLength(50)]
        public string LocationIP { get; set; }

        public DateTime DateView { get; set; }

        public long ChapterId { get; set; }

        public Chapter Chapter { get; set; }

        public Users Useries { get; set; }


        public void GetDateView()
        {
            if (DateView == null)
            {
                DateView = DateTime.Now;
            }
        }
    }
}