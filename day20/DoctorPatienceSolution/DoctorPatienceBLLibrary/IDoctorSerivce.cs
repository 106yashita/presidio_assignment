using ModelClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorPatientBLLibrary
{
    public interface IDoctorSerivce
    {
        int CreateDoctor(Doctor doctor);
        Doctor UpdateDoctor(Doctor doctor);
        Doctor GetDoctorByID(int id);
        List<Doctor> GetDoctorBySpecialization(string specialization);
        List<Doctor> GetDoctorByAvailability(bool available);
        List<Doctor> GetAllDoctors();
        Doctor DeleteDoctor(int id);

    }
}
