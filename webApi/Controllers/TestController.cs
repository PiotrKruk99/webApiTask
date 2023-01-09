using Microsoft.AspNetCore.Mvc;
using webApi.DataClasses.Entities;
using webApi.Services;

namespace webApi.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class TestController : Controller
    {
        private TestEntityService _service;

        public TestController(TestEntityService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return Ok("to jest test");
        }

        [HttpPost]
        public async Task<IActionResult> AddEntiry([FromBody] TestEntityOne entity)
        {
            await _service.AddTestEtity(entity);

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEntities()
        {
            var result = await _service.GetTestEntities();
            return Ok(result);
        }
    }
}
