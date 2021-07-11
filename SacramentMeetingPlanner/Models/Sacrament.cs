using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SacramentMeetingPlanner.Models
{
    public class Sacrament
    {
        public int ID { get; set; }

        [DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        public string Presiding { get; set; }

        public string Conducting { get; set; }

        [Display(Name = "Opening Hymn")]
        public string OpeningHymn { get; set; }
        
        [Display(Name = "Opening Prayer")]
        public string OpeningPrayer { get; set; }

        [Display(Name = "Sacrament Hymn")]
        public string SacramentHymn { get; set; }
        
        [Display(Name = "Intermediate Hymn")]
        public string? IntermediateHymn { get; set; }

        [Display(Name = "Closing Hymn")]
        public string ClosingHymn { get; set; }

        [Display(Name = "Closing Prayer")]
        public string ClosingPrayer { get; set; }

        //Navigation
        public ICollection<Speaker> Speakers { get; set; }

        
    }
}
