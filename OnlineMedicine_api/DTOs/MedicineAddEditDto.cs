using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineMedicine_api.DTOs
{
    public class MedicineAddEditDto
    {
        public int medicineId { get; set; }
        public string name { get; set; }
        public string supplier { get; set; }
        public string manufacture { get; set; }
        public string description { get; set; }
    }
}
