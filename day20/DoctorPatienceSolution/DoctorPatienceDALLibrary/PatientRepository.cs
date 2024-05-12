using DoctorPatientDALLibrary.contexts;
using ModelClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorPatientDALLibrary
{
    public class PatientRepository : IRepository<int , Patient>
    {
        private readonly DoctorPatientContext _context;
        public PatientRepository(DoctorPatientContext context)
        {
            _context = context;
        }

        public Patient Add(Patient item)
        {
            _context.Patients.Add(item);
            _context.SaveChanges();
            return item;
        }

        public Patient Get(int key)
        {
            return _context.Patients.Find(key);
        }

        public List<Patient> GetAll()
        {
            return _context.Patients.ToList();
        }

        public Patient Update(Patient item)
        {
            _context.Patients.Update(item);
            _context.SaveChanges();
            return item;
        }

        public Patient Delete(int key)
        {
            var patient = _context.Patients.Find(key);
            if (patient != null)
            {
                _context.Patients.Remove(patient);
                _context.SaveChanges();
            }
            return patient;
        }
    }
}
