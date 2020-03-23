using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineMedicine_api.Data;
using OnlineMedicine_api.Models;

namespace OnlineMedicine_api.Services
{
    public class SelectService : ISelectService
    {
        private readonly dbOnlineMedicineContext _dbcontext;

        public SelectService(dbOnlineMedicineContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public IEnumerable<KeyValueItem> GetAllMedicines()
        {
            return _dbcontext.Medicine.Select(x => new KeyValueItem()
            {
                Key= x.Id,
                Value =x.Name
            }).ToList();
        }
    }
}
