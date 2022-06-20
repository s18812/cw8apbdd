using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ZADANIE_8_APBD.Models;
using ZADANIE_8_APBD.Models.DTOs;
using ZADANIE_8_APBD.Services;

namespace ZADANIE_8_APBD.Controllers
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

        [HttpPut]
        public async Task<IActionResult> UpdateDoctor(int id, Doctor data)
        {
            var doctor = await _service.GetDoctorByID(id);
            if (doctor == null) return NotFound();

            doctor.FirstName = data.FirstName;
            doctor.LastName = data.LastName;
            doctor.Email = data.Email;
            await _service.SaveDatabase();

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetDoctor(int id)
        {
            var doctor = await _service.GetDoctorByID(id);
            if (doctor == null) return NotFound();

            return Ok(doctor);
        }

        [HttpPost]
        public async Task<IActionResult> AddDoctor(DoctorPost body)
        {
            var doctor = new Doctor
            {
                FirstName = body.FirstName,
                LastName = body.LastName,
                Email = body.Email

            };
            await _service.AddDoctor(doctor);

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveDoctor(int id)
        {
            await _service.Delete(id);

            return Ok();
        }
    }
}
