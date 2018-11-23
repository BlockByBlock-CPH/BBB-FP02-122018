using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BBBWebApiCodeFirst.Models
{
    public class MtcActivity
    {
        [Key]
        
        public int IdAct { get; set; }

        public Mtc Mtc { get; set; }
        [ForeignKey("Mtc")]
        public int ZoneAct { get; set; }
        
        public long CountAct { get; set; }
        public int HoursAct { get; set; }


        public Days Days { get; set; }
        [ForeignKey("Days")]
        public int DaysAct { get; set; }

        public decimal? Density { get; set; }
    }
}
