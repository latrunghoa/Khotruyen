using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KhotruyenM.Models
{
    public class Users
    {
        [Key]
        public long UserId { get; set; }

        [Required]
        [StringLength(100)]
        public string UserName { get; set; }

        [Required]
        [StringLength(30)]
        public string Password { get; set; }

        public string DisplayName { get; set; }

        public string Email { get; set; }

        public string Avatar { get; set; }

        public DateTime CreateDate { get; set; }

        public long RoleID { get; set; }

        public Role Role { get; set; }


        public void GetCurrentDate()
        {
            if (CreateDate == null)
            {
                CreateDate = DateTime.Now;
            }
        }
    }
}