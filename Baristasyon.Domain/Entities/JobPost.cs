using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baristasyon.Domain.Entities
{
    public class JobPost
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string CompanyName { get; set; } = null!;
        public string Location { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string ContactEmail { get; set; } = null!;
        public DateTime PostedAt { get; set; } = DateTime.UtcNow;
    }
}
