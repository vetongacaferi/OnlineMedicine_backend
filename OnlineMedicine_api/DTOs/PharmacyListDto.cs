using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineMedicine_api.DTOs
{
    public class PharmacyListDto
    {
        public int Id { get; set; }
        public string PharmacyName { get; set; }
        public string Photo { get; set; }
    }
}
