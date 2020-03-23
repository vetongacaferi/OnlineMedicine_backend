using Microsoft.AspNetCore.Mvc;
using OnlineMedicine_api.DTOs;
using OnlineMedicine_api.Interfaces;
using OnlineMedicine_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineMedicine_api.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class MedicineController : ControllerBase
    {
        private IMedicineRepository _medicineRepository;

        public MedicineController(IMedicineRepository medicineRepository)
        {
            _medicineRepository = medicineRepository;
        }

        [HttpGet("GetAllMedicines")]
        public async Task<IActionResult> GetAllMedicines()
        {
            var medicines = await _medicineRepository.GetAllMedicines();

            if (medicines == null)
                return NoContent();


            var medicinesResult = new List<MedicineListDto>();

            foreach(var medicine in medicines)
            {
                medicinesResult.Add(new MedicineListDto()
                {
                    Id = medicine.Id,
                    Name = medicine.Name,
                    Description = medicine.Description,
                    Manufacture = medicine.Manufacture,
                    Supplier = medicine.Supplier
                });
            }


            return Ok(medicinesResult);
        }


        [HttpGet("GetMedicine/{id}")]
        public async Task<IActionResult> GetMedicine(int id)
        {
            var medicine = await _medicineRepository.GetMedicine(id);

            if(medicine == null)
            {
                return NotFound();
            }


            var medicineResult = new MedicineListDto()
            {
                Id = medicine.Id,
                Name = medicine.Name,
                Description = medicine.Description,
                Manufacture = medicine.Manufacture,
                Supplier = medicine.Supplier
            };



            return Ok(medicineResult);
        }

        [HttpPost("AddEditMedicine")]
        public async Task<IActionResult> AddEditPharmacy([FromBody]MedicineAddEditDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            
            //edit
            if(model.medicineId == 0)
            {
                var medicineResult = new Medicine()
                {
                    Name = model.name,
                    Description = model.description,
                    Manufacture = model.manufacture,
                    Supplier = model.supplier
                };

                _medicineRepository.AddMedicine(medicineResult);
            }
            else
            {
                var medicinResult = await _medicineRepository.GetMedicine(model.medicineId);

                if(medicinResult == null)
                {
                    return BadRequest();
                }

                medicinResult.Name = model.name;
                medicinResult.Description = model.description;
                medicinResult.Manufacture = model.manufacture;
                medicinResult.Supplier = model.supplier;

                _medicineRepository.UpdateMedicine(medicinResult);
            }
            

            if (_medicineRepository.SaveChanges() > 0)
            {
                return Ok();
            }

            return BadRequest();
        }

    }
}
