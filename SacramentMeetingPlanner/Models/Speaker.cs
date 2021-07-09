using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SacramentMeetingPlanner.Models
{
    public class Speaker
    {
        public int SpeakerID { get; set; }

        public string SpeakerName { get; set; }

        public string Topic { get; set; }


        public ICollection<Enrollment> Enrollments { get; set; }

    }
}
