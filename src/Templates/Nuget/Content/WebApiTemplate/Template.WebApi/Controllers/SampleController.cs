using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Template.IApplication;

namespace Template.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SampleController : ControllerBase
    {
        readonly ISampleService _sampleService;
        public SampleController(
            ISampleService sampleService
            )
        {
            _sampleService = sampleService;
        }
        // GET api/values
        [HttpGet]
        [Route("GetOneSampleVersion")]
        public async Task<string> GetOneSampleVersion()
        {
            return await Task.Run(() => _sampleService.GetOne()?.Version);
        }

    }
}
