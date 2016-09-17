namespace WebsitePerformance.ContractsBetweenBLLandDAL.Entities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("website_performance.website")]
    public partial class website
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public website()
        {
            links = new HashSet<link>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(100)]
        public string url { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<link> links { get; set; }
    }
}
