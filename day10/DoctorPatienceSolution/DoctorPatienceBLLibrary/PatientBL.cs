using DoctorPatientDALLibrary;
using ModelClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace DoctorPatientBLLibrary
{
    public class PatientBL : IPatientService
    {
        readonly IRepository<int, Patient> _patientRepository;

        public PatientBL(IRepository<int, Patient> patientRepository)
        {
            _patientRepository = patientRepository;
        }
        public int CreatePatient(Patient patient)
        {
            Patient result = _patientRepository.Add(patient);
            if (result == null)
            {
                throw new DuplicatePatientNameException();
            }
            return result.PatienceID;
        }

        public Patient DeletePatient(int id)
        {
            Patient result = _patientRepository.Delete(id);
            if (result != null)
            {
                return result;
            }
            throw new PatientNotExistsException();
        }

        public List<Patient> GetAllPatients()
        {
            return _patientRepository.GetAll();
        }

        public Patient GetPatientByID(int id)
        {
            var patient = _patientRepository.Get(id);
            if (patient != null)
            {
                return patient;
            }
            throw new PatientNotExistsException();
        }

        public Patient UpdatePatient(Patient patient)
        {
            int id = patient.PatienceID;
            Patient patient1 = _patientRepository.Get(id);
            if (patient1 != null)
            {
                patient1 = patient;
                return patient1;
            }
            throw new PatientNotExistsException();
        }
    }
}
