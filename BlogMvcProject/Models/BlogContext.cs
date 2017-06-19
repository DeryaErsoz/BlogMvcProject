using BlogMvcProject.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace BlogMvcProject.Models
{
    public class BlogContext: IdentityDbContext<ApplicationUser>
    {
        public BlogContext():base("blogDB")
        {
            Database.SetInitializer(new BlogInitializer());
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Resume> Resumes { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Portfolio> Portfolios { get; set; }
        public DbSet<JobPositionType> JobPositionTypes { get; set; }
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<FeedBack> FeedBacks { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

        modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

        base.OnModelCreating(modelBuilder);

        }
}
}