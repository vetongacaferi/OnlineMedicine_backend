using OnlineMedicine_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineMedicine_api.Interfaces
{
    public interface IPharmacyRepository
    {

        Task<IEnumerable<Pharmacy>> GetAllPharmacies();

        Task<Pharmacy> GetPharmacy(int medicineId);

        void AddPharmacy(Pharmacy model);

        void UpdatePharmacy(Pharmacy model);

        Task<IEnumerable<PharmacyMedicines>> GetPharmacyMedicines(int pharmacyId);

        Task<PharmacyMedicines> getPharmacyMedicine(int pharmacyId, int medicineId);

        void addParmacyMedicine(PharmacyMedicines model);

        void updateParmacyMedicine(PharmacyMedicines model);        

        int SaveChanges();
    }
}
