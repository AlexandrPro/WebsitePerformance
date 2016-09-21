namespace WebsitePerformance.DAL.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using WebsitePerformance.ContractsBetweenBLLandDAL.Entities;

    public partial class WebsitePerformanceModel : DbContext
    {
        public WebsitePerformanceModel()
            : base("name=WebsitePerformanceModel")
        {
        }

        public virtual DbSet<link> link { get; set; }
        public virtual DbSet<test> test { get; set; }
        public virtual DbSet<website> website { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<link>()
                .Property(e => e.url)
                .IsUnicode(false);

            modelBuilder.Entity<link>()
                .HasMany(e => e.tests)
                .WithRequired(e => e.link)
                .HasForeignKey(e => e.link_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<website>()
                .Property(e => e.url)
                .IsUnicode(false);

            modelBuilder.Entity<website>()
                .HasMany(e => e.links)
                .WithRequired(e => e.website)
                .HasForeignKey(e => e.site_id);
        }
    }
}
