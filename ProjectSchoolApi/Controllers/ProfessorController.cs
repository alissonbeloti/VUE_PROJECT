using Microsoft.AspNetCore.Mvc;

namespace ProjectSchoolApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProfessorController : ControllerBase
    {
        public ProfessorController()
        {

        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }

        [HttpGet("{ProfessorId}")]
        public IActionResult Get(int professorId)
        {
            return Ok();
        }
        [HttpPost]
        public IActionResult Post()
        {
            return Ok();
        }
        [HttpPut("{ProfessorId}")]
        public IActionResult Put(int professorId)
        {
            return Ok();
        }
        [HttpDelete("{ProfessorId}")]
        public IActionResult Delete(int professorId)
        {
            return Ok();
        }
    }
}