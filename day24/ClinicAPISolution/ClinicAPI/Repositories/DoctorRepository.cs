using ClinicAPI.Contexts;
using ClinicAPI.Exceptions;
using ClinicAPI.Interfaces;
using ClinicAPI.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ClinicAPI.Repositories
{
    public class DoctorRepository : IRepository<int,Doctor>
    {
        private readonly ClinicContext _context;
        public DoctorRepository(ClinicContext context)
        {
            _context = context;
        }
        public async Task<Doctor> Add(Doctor item)
        {
            _context.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<Doctor> Delete(int key)
        {
            var doctor = await Get(key);
            if (doctor != null)
            {
                _context.Remove(doctor);
                _context.SaveChangesAsync(true);
                return doctor;
            }
            throw new NoSuchDoctorException();
        }

        public Task<Doctor> Get(int key)
        {
            var doctor = _context.Doctors.FirstOrDefaultAsync(e => e.id == key);
            return doctor;
        }

        public async Task<IEnumerable<Doctor>> Get()
        {
            var doctors = await _context.Doctors.ToListAsync();
            return doctors;

        }

        public async Task<Doctor> Update(Doctor item)
        {
            var doctor = await Get(item.id);
            if (doctor != null)
            {
                _context.Update(item);
                _context.SaveChangesAsync(true);
                return doctor;
            }
            throw new NoSuchDoctorException();
        }
    }

}
