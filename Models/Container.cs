using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FloraTransAPI.Models
{
    public class Container
    {
        [Key]
        public int CCTag { get; set; }
        public DateTime RentTimeStamp { get; set; }
        public DateTime ReturnTimeStamp { get; set; }
        public bool Available { get; set; }
        public bool Lost { get; set; }

    }
}
