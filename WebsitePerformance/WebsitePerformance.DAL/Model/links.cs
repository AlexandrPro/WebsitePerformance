namespace WebsitePerformance.DAL.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("website_performance.links")]
    public partial class links
    {
        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string url { get; set; }

        public int? s { get; set; }

        public int? ms { get; set; }

        public int site_id { get; set; }

        public virtual website website { get; set; }
    }
}
