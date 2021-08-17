using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FloraTransAPI.Models
{
    public class Client
    {
        public int ClientID { get; set; }
        public int CVR { get; set; }
        public string Address { get; set; }
        public Contact Contact { get; set; }
        public IEnumerable<Container>? RentedContainer { get; set; }
    }
}
