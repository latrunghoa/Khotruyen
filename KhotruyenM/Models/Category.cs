using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KhotruyenM.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [StringLength(255)]
        public string Metatitle { get; set; }

        public DateTime CreateDate { get; set; }

        public string CreateBy { get; set; }

        public void GetCurrentDate()
        {
            if (CreateDate == null)
            {
                CreateDate = DateTime.Now;
            }
        }
    }
}