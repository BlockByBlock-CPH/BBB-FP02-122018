using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BBBWebApiCodeFirst.Models
{
    public class MtcHomezone
    {

        [Key]
        public int IdHz { get; set; }

   
        public int ZoneHz { get; set; }

        public Mtc Mtc { get; set; }

        [ForeignKey("Mtc")]
        public int HomeHz { get; set; }

        public int DaysHz { get; set; }

        public decimal SharedHz { get; set; }

               




    }
}
