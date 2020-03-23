using System;
using System.Collections.Generic;

namespace OnlineMedicine_api.Models
{
    public partial class PharmacyMedicines
    {
        public int Id { get; set; }
        public int PharmacyId { get; set; }
        public int MedicineId { get; set; }
        public int Quantity { get; set; }
        public bool IsDeleted { get; set; }

        public Medicine Medicine { get; set; }
        public Pharmacy Pharmacy { get; set; }
    }
}
