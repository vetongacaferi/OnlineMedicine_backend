using OnlineMedicine_api.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineMedicine_api.Services
{
    public interface ISelectService
    {

        IEnumerable<KeyValueItem> GetAllMedicines();
    }
}
