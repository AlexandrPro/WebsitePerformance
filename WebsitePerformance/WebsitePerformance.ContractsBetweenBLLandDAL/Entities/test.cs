namespace WebsitePerformance.ContractsBetweenBLLandDAL.Entities
{
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("website_performance.test")]
    public partial class test
    {
        public int id { get; set; }

        public int link_id { get; set; }

        public int number { get; set; }

        public float time { get; set; }

        public virtual link link { get; set; }
    }
}
