using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IT_EComm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LaptopController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<LaptopController> GetLaptop()
        {
            
        }
    }
}
