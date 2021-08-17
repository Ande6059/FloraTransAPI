using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FloraTransAPI.Models
{
    public class ContainerAssignment
    {
        public int ContainerID { get; set; }
        public int ClientID { get; set; }
        public Container Container { get; set; }
        public Client Client { get; set; }
    }
}
