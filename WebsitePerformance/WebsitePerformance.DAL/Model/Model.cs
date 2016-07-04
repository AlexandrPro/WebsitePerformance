namespace WebsitePerformance.DAL.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model : DbContext
    {
        public Model()
            : base("name=WPModel")
        {
        }

        public virtual DbSet<links> links { get; set; }
        public virtual DbSet<website> website { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<links>()
                .Property(e => e.url)
                .IsUnicode(false);

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
