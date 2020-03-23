using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineMedicine_api.DTOs
{
    public class PharmacyMedicinesAddDto
    {
        public int id { get; set; }
        public string name { get; set; }
        public int Quantity { get; set; }
        public bool isSelected {get;set;}
    }

    public class PharmacyMedicineDto
    {
        public List<PharmacyMedicinesAddDto> items { get; set; }
    }
}
