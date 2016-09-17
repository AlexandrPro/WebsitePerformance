using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebsitePerformance.Contracts.DTO
{
    class LinkViewModel
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public int LastButOneTest { get; set; } //предпоследний
        public int LastTest { get; set; } //последний
        public int NewTest { get; set; }
    }
}
