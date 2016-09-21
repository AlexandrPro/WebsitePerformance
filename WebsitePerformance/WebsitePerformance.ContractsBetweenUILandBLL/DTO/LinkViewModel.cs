using System.ComponentModel.DataAnnotations;

namespace WebsitePerformance.ContractsBetweenUILandBLL.DTO
{
    public class LinkViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Url { get; set; }

        [Required]
        public double LastTest { get; set;}

        [Required]
        public double NewTest { get; set; }
    }
}
