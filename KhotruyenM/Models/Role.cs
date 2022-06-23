using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KhotruyenM.Models
{
    public class Role
    {
        [Key]
        public long RoleId { get; set; }

        [Required]
        public string Name { get; set; }
    }
}