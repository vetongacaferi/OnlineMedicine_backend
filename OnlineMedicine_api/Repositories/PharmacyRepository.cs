using Microsoft.EntityFrameworkCore;
using OnlineMedicine_api.Interfaces;
using OnlineMedicine_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineMedicine_api.Repositories
{
    public class PharmacyRepository : IPharmacyRepository
    {
        private dbOnlineMedicineContext _context;
        public PharmacyRepository(dbOnlineMedicineContext context)
        {
            _context = context;
        }

        public void AddPharmacy(Pharmacy model)
        {
            _context.Pharmacy.Add(model);
        }

        public async Task<IEnumerable<Pharmacy>> GetAllPharmacies()
        {
                return await   _context.Pharmacy.ToListAsync();
        }

        public async Task<Pharmacy> GetPharmacy(int medicineId)
        {
            return await _context.Pharmacy.FirstOrDefaultAsync(x => x.Id == medicineId);
        }

      
        public void UpdatePharmacy(Pharmacy model)
        {
            _context.Pharmacy.Update(model);
        }

        public async Task<IEnumerable<PharmacyMedicines>> GetPharmacyMedicines(int pharmacyId)
        {
            return await _context.PharmacyMedicines.Where(x =>x.PharmacyId == pharmacyId && x.IsDeleted == false).ToListAsync();
        }

       public async  Task<PharmacyMedicines> getPharmacyMedicine(int pharmacyId, int medicineId)
        {
            return await _context.PharmacyMedicines.Where(x => x.PharmacyId == pharmacyId && x.MedicineId == medicineId).FirstOrDefaultAsync();
        }

        public void addParmacyMedicine(PharmacyMedicines model)
        {
            _context.PharmacyMedicines.Add(model);
        }

        public void updateParmacyMedicine(PharmacyMedicines model)
        {
            _context.PharmacyMedicines.Update(model);
        }


        public int SaveChanges()
        {
           return _context.SaveChanges();
        }

    }
}
