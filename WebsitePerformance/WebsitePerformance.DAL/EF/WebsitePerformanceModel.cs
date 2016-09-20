namespace WebsitePerformance.DAL.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class WebsitePerformanceModel : DbContext
    {
        public WebsitePerformanceModel()
            : base("name=WebsitePerformanceModel")
        {
        }

        public virtual DbSet<links> links { get; set; }
        public virtual DbSet<test> test { get; set; }
        public virtual DbSet<website> website { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<links>()
                .Property(e => e.url)
                .IsUnicode(false);

            modelBuilder.Entity<links>()
                .HasMany(e => e.test)
                .WithRequired(e => e.links)
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
