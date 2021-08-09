using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FloraTransAPI.Models
{
    public class Warehouse
    {
        public int ID { get; set; }
        public int RentedContainersCC { get; set; }
        public int AvailableContainers { get; set; }
    }
}
