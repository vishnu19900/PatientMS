using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PatientMS.Models;

namespace PatientMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        IPatientService patientService;
        public PatientController(IPatientService _patientService)
        {
            this.patientService = _patientService;
        }

        [HttpGet("Get")]
        public IActionResult Get(int Id)
        {
            var allPat = this.patientService.GetById(Id);
            return Ok(allPat);
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var allPat = this.patientService.GetAll();
            return Ok(allPat);
        }

        [HttpPost("Add")]
        public IActionResult Add(Patient pat)
        {
            var patObj = this.patientService.Add(pat);
            return Ok(patObj);
        }

        [HttpPut("update")]
        public IActionResult Update(Patient pat)
        {
            var patObj = this.patientService.Update(pat);
            return Ok(patObj);
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int Id)
        {
            var pat = this.patientService.Delete(Id);
            return Ok(pat);
        }
    }
}
