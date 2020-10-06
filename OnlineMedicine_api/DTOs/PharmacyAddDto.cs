using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineMedicine_api.DTOs
{
    public class PharmacyAddDto
    {
        public string PharmacyName { get; set; }
        public string Photo { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
    }
}
