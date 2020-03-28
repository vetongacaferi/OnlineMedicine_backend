using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineMedicine_api.DTOs
{
    public class ProfileDto
    {
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string username { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zipcode { get; set; }
    }
}
