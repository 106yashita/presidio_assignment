using ModelClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorPatientBLLibrary
{
    public interface IPatientService
    {
        int CreatePatient(Patient patient);
        Patient UpdatePatient(Patient patient);
        Patient GetPatientByID(int id);
        List<Patient> GetAllPatients();
        Patient DeletePatient(int id);
    }
}
