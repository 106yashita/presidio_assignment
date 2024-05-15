using ClinicAPI.Exceptions;
using ClinicAPI.Interfaces;
using ClinicAPI.models;
using Microsoft.AspNetCore.Mvc;

namespace ClinicAPI.Controllers
{
        [Route("api/[controller]")]
        [ApiController]
        public class DoctorController : ControllerBase
        {
            private readonly IDoctorService _doctorService;

            public DoctorController(IDoctorService employeeService)
            {
                _doctorService = employeeService;
            }
            [HttpGet]
            public async Task<ActionResult<IList<Doctor>>> Get()
            {
                try
                {
                    var doctors = await _doctorService.GetDoctors();
                    return Ok(doctors.ToList());
                }
                catch (NoDoctorFoundException ndfe)
                {
                    return NotFound(ndfe.Message);
                }
            }
            [HttpPut]
            public async Task<ActionResult<Doctor>> Put(int id, int experience)
            {
                try
                {
                    var doctor = await _doctorService.UpdateDoctorExperience(id, experience);
                    return Ok(doctor);
                }
                catch (NoSuchDoctorException nsde)
                {
                    return NotFound(nsde.Message);
                }
            }
            [Route("GetDoctorbySpeciality")]
            [HttpGet]
            public async Task<ActionResult<IEnumerable<Doctor>>> GetBySpeciality(string speciality)
            {
                try
                {
                    var doctors = await _doctorService.GetDoctorsBySpeciality(speciality);
                    return Ok(doctors);
                }
                catch (NoDoctorFoundException nsde)
                {
                    return NotFound(nsde.Message);
                }
            }
        }
}
