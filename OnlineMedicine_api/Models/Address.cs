using System;
using System.Collections.Generic;

namespace OnlineMedicine_api.Models
{
    public partial class Address
    {
        public Address()
        {
            Pharmacy = new HashSet<Pharmacy>();
        }

        public int Id { get; set; }
        public string City { get; set; }
        public string Location { get; set; }

        public ICollection<Pharmacy> Pharmacy { get; set; }
    }
}
