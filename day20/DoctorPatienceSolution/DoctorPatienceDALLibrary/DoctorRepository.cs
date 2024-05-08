using DoctorPatientDALLibrary.contexts;
using ModelClassLibrary;

namespace DoctorPatientDALLibrary
{
    public class DoctorRepository : IRepository<int, Doctor>
    {
        //readonly Dictionary<int, Doctor> _doctors;
        private readonly DoctorPatientContext _context;
        public DoctorRepository(DoctorPatientContext context)
        {
            _context = context;
        }

        //int GenerateId()
        //{
        //    if (_doctors.Count == 0)
        //        return 1;
        //    int id = _doctors.Keys.Max();
        //    return ++id;
        //}

        public Doctor Add(Doctor item)
        {
            //if (_doctors.ContainsValue(item))
            //{
            //    return null;
            //}
            //_doctors.Add(GenerateId(), item);
            //return item;
            _context.doctors.Add(item);
            _context.SaveChanges();
            return item;
        }

        public Doctor Get(int key)
        {
            //return  _doctors[key] ?? null;
            return _context.doctors.Find(key);
        }

        public List<Doctor> GetAll()
        {
            //if (_doctors.Count == 0)
            //    return null;
            //return _doctors.Values.ToList();
            return _context.doctors.ToList();
        }

        public Doctor Update(Doctor item)
        {
            //if (_doctors.ContainsKey(item.DoctorID))
            //{
            //    _doctors[item.DoctorID] = item;
            //    return item;
            //}
            //return null;
            _context.doctors.Update(item);
            _context.SaveChanges();
            return item;
        }  

        public Doctor Delete(int key)
        {
            //if (_doctors.ContainsKey(key))
            //{
            //    var doctor = _doctors[key];
            //    _doctors.Remove(key);
            //    return doctor;
            //}
            //return null;
            var doctor = _context.doctors.Find(key);
            if (doctor != null)
            {
                _context.doctors.Remove(doctor);
                _context.SaveChanges();
            }
            return doctor;
        }

        
    }
}
