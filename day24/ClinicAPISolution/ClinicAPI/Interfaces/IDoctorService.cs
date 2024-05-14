using ClinicAPI.models;

namespace ClinicAPI.Interfaces
{
    public interface IDoctorService
    {
        public Task<Doctor> UpdateDoctorExperience(int id, int experience);
        public Task<IEnumerable<Doctor>> GetDoctors();
        public Task<IEnumerable<Doctor>> GetDoctorsBySpeciality(string speciality);
    }
}
