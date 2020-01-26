using Microsoft.AspNetCore.Mvc;

namespace ProjectSchoolApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AlunoController : ControllerBase
    {
        public AlunoController()
        {

        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }

        [HttpGet("{AlunoId}")]
        public IActionResult Get(int alunoId)
        {
            return Ok();
        }
        [HttpPost]
        public IActionResult Post()
        {
            return Ok();
        }
        [HttpPut("{AlunoId}")]
        public IActionResult Put(int alunoId)
        {
            return Ok();
        }
        [HttpDelete("{AlunoId}")]
        public IActionResult Delete(int alunoId)
        {
            return Ok();
        }
    }
}