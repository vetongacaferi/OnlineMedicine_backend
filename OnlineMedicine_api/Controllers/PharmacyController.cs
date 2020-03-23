using Microsoft.AspNetCore.Mvc;
using OnlineMedicine_api.DTOs;
using OnlineMedicine_api.Interfaces;
using OnlineMedicine_api.Models;
using OnlineMedicine_api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineMedicine_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PharmacyController : ControllerBase
    {

        private IPharmacyRepository _pharmacyRepository;
        private ISelectService _selectService;

        public PharmacyController(IPharmacyRepository pharmacyRepository, ISelectService selectService)
        {
            _pharmacyRepository = pharmacyRepository;
            _selectService = selectService;
        }

        [HttpGet("GetAllPharamcies")]
        public async Task<IActionResult> GetAllPharmacy()
        {
            var pharmacies = await _pharmacyRepository.GetAllPharmacies();
            if (pharmacies == null)
            {
                return NotFound();
            }

            var medicineResult = new List<PharmacyListDto>();


            foreach (var medicine in pharmacies)
            {
                medicineResult.Add(new PharmacyListDto()
                {
                    Id = medicine.Id,
                    PharmacyName = medicine.PharmacyName,
                    Photo = medicine.Photo
                });
            }


            return Ok(medicineResult);

        }


        [HttpGet("GetPharamcy/{id}")]
        public async Task<IActionResult> GetPharmacy(int id)
        {
            var pharmacy = await _pharmacyRepository.GetPharmacy(id);

            if (pharmacy == null)
            {
                return NotFound();
            }

            var pharmacyResult = new PharmacyListDto()
            {
                Id = pharmacy.Id,
                PharmacyName = pharmacy.PharmacyName,
                Photo = pharmacy.Photo
            };

            return Ok(pharmacyResult);
        }

        [HttpPost("AddPharmacy")]
        public async Task<IActionResult> AddPharmacy([FromBody]PharmacyAddDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var pharmacyResult = new Pharmacy()
            {
                PharmacyName = model.PharmacyName,
                Photo = model.Photo
            };

            _pharmacyRepository.AddPharmacy(pharmacyResult);

            if (_pharmacyRepository.SaveChanges() > 0)
            {
                return Ok();
            }

            return BadRequest();
        }



        [HttpPut("EditPharmacy/{id}")]
        public async Task<IActionResult> EditPharmacy(int id, [FromBody]PharmacyAddDto model)
        {
            var pharmacy = await _pharmacyRepository.GetPharmacy(id);

            if (pharmacy == null)
            {
                return BadRequest();
            }

            pharmacy.PharmacyName = model.PharmacyName;
            pharmacy.Photo = model.Photo;

            _pharmacyRepository.UpdatePharmacy(pharmacy);

            if (_pharmacyRepository.SaveChanges() > 0)
            {
                return Ok();
            }

            return BadRequest();


        }

        [HttpGet("GetPharmacyMedicines/{id}")]
        public async Task<IActionResult> GetPharmacyMedicines(int id)
        {
            var medicineSelectList = _selectService.GetAllMedicines();

            var medicinePharmacyR = await _pharmacyRepository.GetPharmacyMedicines(id);

            var result =
                    from medicineSelect in medicineSelectList
                    join medicinePharmacy in medicinePharmacyR on medicineSelect.Key equals medicinePharmacy.MedicineId into ps
                    from medicine in ps.DefaultIfEmpty()
                    select new {
                        Id = medicineSelect.Key,
                        Name = medicineSelect.Value,
                        Quantity = (medicine == null ? 0 : medicine.Quantity),
                        IsSelected = (medicine == null ? false : true)
                    };

            return Ok(result);
        }

        [HttpPut("UpdatePharmacyMecicines/{id}")]
        public async Task<IActionResult> UpdatePharmacyMecicines(int id, [FromBody] PharmacyMedicineDto model)
        {
            bool isInsideAddUpdate = false;
            foreach(var item in model.items)
            {
                var pharmacyMedicine = await  _pharmacyRepository.getPharmacyMedicine(id, item.id);

                if(pharmacyMedicine == null && item.isSelected == true)//
                {
                    var modelAddResult = new PharmacyMedicines()
                    {
                        PharmacyId = id,
                        MedicineId = item.id,
                        Quantity = item.Quantity,
                        IsDeleted = false
                    };

                    _pharmacyRepository.addParmacyMedicine(modelAddResult);
                    isInsideAddUpdate = true;
                }

                else if(pharmacyMedicine != null)
                {
                    pharmacyMedicine.IsDeleted = !item.isSelected;
                    pharmacyMedicine.Quantity = item.Quantity;

                    _pharmacyRepository.updateParmacyMedicine(pharmacyMedicine);
                    isInsideAddUpdate = true;

                }
            }

            if (_pharmacyRepository.SaveChanges() > 0 || isInsideAddUpdate == false)
            {
                return Ok();
            }

            return BadRequest();

        }

    }
}
