using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employex.Models
{
    class JobOffer
    {
        public string job_offer_id { get; set; }
        public string job { get; set; }
        public string description { get; set; }
        public string job_category { get; set; }
        public string location { get; set; }
    }
}
