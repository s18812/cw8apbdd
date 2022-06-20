using ZADANIE_8_APBD.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using ZADANIE_8_APBD.Services;
using System.Linq;

namespace ZADANIE_8_APBD.Services
{
    public class MedService : IMedService
    {

        private readonly MyDbContext _context;

        public MedService(MyDbContext context)
        {
            _context = context;
        }

        public async Task<Doctor> GetDoctorByID(int id)
        {
            return await _context.Doctors.FirstOrDefaultAsync(e => e.IdDoctor== id);
        }

        public async Task AddDoctor(Doctor doctor)
        {
            _context.Add<Doctor>(doctor);
            await _context.SaveChangesAsync();
        }

        public async Task SaveDatabase()
        {
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var doctor = await GetDoctorByID(id);
            _context.Doctors.Attach(doctor);
            _context.Doctors.Remove(doctor);

            await _context.SaveChangesAsync();
        }

        public async Task<Medicament> GetMedicamentByID(int id)
        {
            return await _context.Medicaments.FirstOrDefaultAsync(e => e.IdMedicament == id);
        }

        public async Task<Prescription> GetPrescriptionByID(int id)
        {
            return await _context.Prescriptions.FirstOrDefaultAsync(e => e.IdPrescription == id);
        }
    }
}
