using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlenkaForms.src.Domain.Entities.Models
{
    public class MasterCatalog
    {
        public string MasterId { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }

        public string DetailId { get; set; }
        public string DetailDescription { get; set; }
        public bool DetailActive { get; set; }
    }
}
