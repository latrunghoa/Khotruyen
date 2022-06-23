using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace KhotruyenM.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Category> categories { get; set; }

        public DbSet<Chapter> chapters { get; set; }

        public DbSet<Comment> comments { get; set; }

        public DbSet<History> histories { get; set; }

        public DbSet<Report> reports { get; set; }

        public DbSet<Role> roles { get; set; }

        public DbSet<Story> stories { get; set; }


        public DbSet<Users> useries { get; set; }

        public DbSet<UserFollow> userFollows { get; set; }

        public DbSet<UserRating> userRatings { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}