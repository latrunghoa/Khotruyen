using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KhotruyenM.Models
{
    public class UserRating
    {
        [StringLength(50)]
        public string LocationIP { get; set; }

        public float Rating { get; set; }

        public DateTime CreateDate { get; set; }

        public Story Story { get; set; }

        [Key, Column(Order = 2)]
        public long StoryId { get; set; }

        public Users Useries { get; set; }

        [Key, Column(Order = 1)]
        public long UserId { get; set; }
    }
}