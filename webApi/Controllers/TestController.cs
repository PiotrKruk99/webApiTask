using Microsoft.AspNetCore.Mvc;
using webApi.DataClasses.Entities;
using webApi.Services;

namespace webApi.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class TestController : Controller
    {
        private readonly ITestEntityService _service;

        public TestController(ITestEntityService service)
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

        [HttpPost]
        public async Task<IActionResult> AllowedMethodsTest([FromBody] int id)
        {
            var result = await _service.AllowedMethodsTest(id);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> MethodInMethod()
        {
            var result = await _service.MethodInMethod();
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> MethodsManyTimes()
        {
            var result = await _service.MethodsManyTimes();
            return Ok(result);
        }
    }
}
