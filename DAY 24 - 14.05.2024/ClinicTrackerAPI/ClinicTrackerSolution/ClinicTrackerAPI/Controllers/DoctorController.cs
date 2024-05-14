using ClinicTrackerAPI.Exceptions;
using ClinicTrackerAPI.Interfaces;
using ClinicTrackerAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicTrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService _doctorService;
        public DoctorController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        [HttpGet]
        public async Task<IList<Doctor>> Get()
        {
            var doctors = await _doctorService.GetDoctors();
            return doctors.ToList();
        }

        [HttpPut]
        public async Task<ActionResult<Doctor>> Put(int id, float experience)
        {
            try
            {
                var doctor = await _doctorService.UpdateDoctorExperience(id, experience);
                return Ok(doctor);
            }
            catch (NoSuchDoctorFoundException nsee)
            {
                return NotFound(nsee.Message);
            }
        }

        [Route("GetDoctorBySpecialization")]
        [HttpPost]

        public async Task<ActionResult<Doctor>> Get([FromBody] string specialization)
        {
            try
            {
                var employee = await _doctorService.GetDoctorBySpecialization(specialization);
                return Ok(employee);
            }
            catch (NoSuchDoctorFoundException nefe)
            {
                return NotFound(nefe.Message);
            }
        }
    }
}
