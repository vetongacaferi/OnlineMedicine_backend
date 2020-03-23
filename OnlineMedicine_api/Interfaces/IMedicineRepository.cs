using OnlineMedicine_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineMedicine_api.Interfaces
{
    public interface IMedicineRepository
    {
        Task<IEnumerable<Medicine>> GetAllMedicines();

        Task<Medicine> GetMedicine(int medicineId);


        void AddMedicine(Medicine model);

        void UpdateMedicine(Medicine model);

        int SaveChanges();
    }
}
