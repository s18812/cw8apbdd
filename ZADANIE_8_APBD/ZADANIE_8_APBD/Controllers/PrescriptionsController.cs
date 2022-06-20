using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZADANIE_8_APBD.Models.DTOs;
using ZADANIE_8_APBD.Services;

namespace ZADANIE_8_APBD.Controllers
{
    public class PrescriptionsController : Controller
    {
        [Route("api/[controller]")]
        [ApiController]
        public class DoctorsController : ControllerBase
        {
            private readonly IMedService _service;
            public DoctorsController(IMedService service)
            {
                _service = service;
            }

            [HttpGet]
            public async Task<IActionResult> GetPrescription(int id)
            {
                var prescription = await _service.GetPrescriptionByID(id);
                if (prescription == null) return NotFound();

                return Ok(new PrescriptionGet
                {
                    Date = prescription.Date,
                    DueDate = prescription.DueDate,
                    Doctor = prescription.Doctor,
                    Patient = prescription.Patient,
                });
              
            }
        }
    }
}
