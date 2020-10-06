using System;
using System.Collections.Generic;

namespace OnlineMedicine_api.Models
{
    public partial class Pharmacy
    {
        public Pharmacy()
        {
            PharmacyMedicines = new HashSet<PharmacyMedicines>();
        }

        public int Id { get; set; }
        public string PharmacyName { get; set; }
        public string Photo { get; set; }
        public int? AddressId { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }

        public Address Address { get; set; }
        public ICollection<PharmacyMedicines> PharmacyMedicines { get; set; }
    }
}
