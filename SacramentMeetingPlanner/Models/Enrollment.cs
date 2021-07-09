using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SacramentMeetingPlanner.Models
{
    public class Enrollment
    {
        public int EnrollmentID { get; set; }

        // Foriegn Key 
        public int SacramentID { get; set; }

        public int SpeakerID { get; set; }

        // Navigation Property 

        public Speaker Speaker { get; set; }

        public Sacrament Sacrament { get; set; }
    }
}
