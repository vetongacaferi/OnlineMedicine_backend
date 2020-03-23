using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineMedicine_api.DTOs
{
    public class RegisterDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        //[Required, MaxLength(256)]
        public string Username { get; set; }
        public string Email { get; set; }
        //[Required, DataType(DataType.Password)]
        public string Password { get; set; }

        //[DataType(DataType.Password), Compare(nameof(Password))]
        //public string ConfirmPassword { get; set; }
    }
}
