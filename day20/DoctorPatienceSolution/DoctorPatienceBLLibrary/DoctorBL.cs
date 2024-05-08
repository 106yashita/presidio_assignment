using DoctorPatientDALLibrary;
using ModelClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorPatientBLLibrary
{
    public class DoctorBL : IDoctorSerivce
    {
        readonly IRepository<int, Doctor> _doctorRepository;

        public DoctorBL(IRepository<int, Doctor> doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        public int CreateDoctor(Doctor doctor)
        {
            var result=_doctorRepository.Add(doctor);
            if(result !=null)
            {
                return result.DoctorID;
            }
            throw new DuplicateDoctorNameException();
        }

        public Doctor DeleteDoctor(int id)
        {
            Doctor result= _doctorRepository.Delete(id);
            if(result!=null)
            {
                return result;
            }
            throw new DoctorNotExistsException();
        }

        public List<Doctor> GetAllDoctors()
        {
           return _doctorRepository.GetAll();
        }

        public List<Doctor> GetDoctorByAvailability(bool available)
        {
            List<Doctor> doctors = _doctorRepository.GetAll();
            List<Doctor> doctors1 = new List<Doctor>();
            foreach (var item in doctors)
            {
                if (item.Available == true) doctors1.Add(item);
            }
            return doctors1;
        }

        public Doctor GetDoctorByID(int id)
        {
            Doctor doctor = _doctorRepository.Get(id);
            if(doctor != null)
            {
                return doctor;
            }
            throw new DoctorNotExistsException();

        }

        public List<Doctor> GetDoctorBySpecialization(string specialization)
        {
            List<Doctor> doctors = _doctorRepository.GetAll();
            List<Doctor> doctors1 = new List<Doctor>();
            foreach (var item in doctors)
            {
                if (item.Specialization == specialization) doctors1.Add(item);
            }
            return doctors1;
        }

        public Doctor UpdateDoctor(Doctor doctor)
        {
            int id=doctor.DoctorID;
            Doctor doctor1 = _doctorRepository.Get(id);
            if(doctor1 != null)
            {
                doctor1 = doctor;
                return doctor1;
            }
            throw new DoctorNotExistsException();
        }
    }
}
