namespace WebsitePerformance.DAL.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("website_performance.test")]
    public partial class test
    {
        public int id { get; set; }

        public int link_id { get; set; }

        public int number { get; set; }

        public int s { get; set; }

        public int ms { get; set; }

        public virtual link link { get; set; }
    }
}
