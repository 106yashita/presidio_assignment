using ClinicAPI.Exceptions;
using ClinicAPI.Interfaces;
using ClinicAPI.models;

namespace ClinicAPI.services
{
    public class DoctorService : IDoctorService
    {
        private readonly IRepository<int, Doctor> _repository;

        public DoctorService(IRepository<int, Doctor> reposiroty)
        {
            _repository = reposiroty;
        }
        public async Task<IEnumerable<Doctor>> GetDoctors()
        {
            var doctors = await _repository.Get();
            if (doctors.Count() == 0)
                throw new NoDoctorFoundException();
            return doctors;
        }

        public async Task<IEnumerable<Doctor>> GetDoctorsBySpeciality(string speciality)
        {
            var doctors = (await _repository.Get()).Where(e => e.speciality == speciality).ToList();
            if (doctors.Count == 0)
                throw new NoDoctorFoundException();
            return doctors;
        }

        public async Task<Doctor> UpdateDoctorExperience(int id, int experience)
        {
            var doctor = await _repository.Get(id);
            if (doctor == null)
                throw new NoSuchDoctorException();
            doctor.experience=experience;
            doctor = await _repository.Update(doctor);
            return doctor; ;
        }
    }
}
