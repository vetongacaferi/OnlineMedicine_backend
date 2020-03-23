using Microsoft.EntityFrameworkCore;
using OnlineMedicine_api.Interfaces;
using OnlineMedicine_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineMedicine_api.Repositories
{
    public class MedicineRepository : IMedicineRepository
    {
        private dbOnlineMedicineContext _context;
        public MedicineRepository(dbOnlineMedicineContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Medicine>> GetAllMedicines()
        {
            return await _context.Medicine.ToListAsync();
        }

        public async Task<Medicine> GetMedicine(int medicineId)
        {
            return await _context.Medicine.FirstOrDefaultAsync(t => t.Id == medicineId);
        }

        public void AddMedicine(Medicine model)
        {
            _context.Medicine.Add(model);

        }

        public void UpdateMedicine(Medicine model)
        {
            _context.Medicine.Update(model);

        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }
    }
}
