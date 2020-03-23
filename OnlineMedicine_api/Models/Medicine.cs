using System;
using System.Collections.Generic;

namespace OnlineMedicine_api.Models
{
    public partial class Medicine
    {
        public Medicine()
        {
            PharmacyMedicines = new HashSet<PharmacyMedicines>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Supplier { get; set; }
        public string Manufacture { get; set; }
        public string Description { get; set; }

        public ICollection<PharmacyMedicines> PharmacyMedicines { get; set; }
    }
}
