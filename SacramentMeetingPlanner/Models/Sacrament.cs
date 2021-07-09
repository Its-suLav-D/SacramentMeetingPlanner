using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SacramentMeetingPlanner.Models
{
    public class Sacrament
    {
        public int SacramentID { get; set; }

        public DateTime Date { get; set; }

        public string Conducting { get; set; }

        public string OpeningHymn { get; set; }

        public string OpeningPrayer { get; set; }

        public string SacramentHymn { get; set; }

        public string? IntermediateHymn { get; set; }

        public string ClosingHymn { get; set; }

        public string ClosingPrayer { get; set; }

        //Navigation
        public ICollection<Speaker> Speakers { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
