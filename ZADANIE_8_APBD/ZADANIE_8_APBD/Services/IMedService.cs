using ZADANIE_8_APBD.Models;
using System.Threading.Tasks;

namespace ZADANIE_8_APBD.Services
{
    public interface IMedService
    {
        public Task<Doctor> GetDoctorByID(int id);
        public Task<Prescription> GetPrescriptionByID(int id);
        public Task<Medicament> GetMedicamentByID(int id);
        public Task SaveDatabase();
        public Task AddDoctor(Doctor doctor);
        public Task Delete(int id);
    }
}
