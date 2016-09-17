namespace WebsitePerformance.ContractsBetweenBLLandDAL.Entities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("website_performance.links")]
    public partial class link
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public link()
        {
            tests = new HashSet<test>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string url { get; set; }

        public int site_id { get; set; }

        public int test_count { get; set; }

        public virtual website website { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<test> tests { get; set; }
    }
}
