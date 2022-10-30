using IT_EComm.Models;
using IT_EComm.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IT_EComm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LaptopController : ControllerBase
    {
        private readonly ILaptopRepository _laptopRepository;

        public LaptopController(ILaptopRepository laptopRepository)
        {
            _laptopRepository = laptopRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Laptop>> GetLaptops()
        {
            return await _laptopRepository.GetAllAsync();
        }
        [HttpGet("{id:int}", Name = "GetLaptop")]
        public async Task<ActionResult<Laptop>> GetLaptops(int id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var foundLaptop = await _laptopRepository.GetAsync(x => x.Id == id);
            if (foundLaptop == null)
            {
                return NotFound();
            }

            return foundLaptop;
        }

        [HttpPost]
        public async Task<ActionResult> CreateLaptop([FromBody] Laptop createLaptop)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            if (await _laptopRepository.GetAsync(u => u.Model == createLaptop.Model) != null)
            {
                return BadRequest();
            }
            if (createLaptop == null)
            {
                return BadRequest();
            }
            await _laptopRepository.CreateAsync(createLaptop);
            return CreatedAtRoute("GetLaptop", new { id = createLaptop.Id },createLaptop);

        }

        [HttpPut]
        public async Task<ActionResult> UpdateLaptop(int id,[FromBody] Laptop updateLaptop)
        {
            if (updateLaptop==null || id!= updateLaptop.Id)
            {
                return BadRequest();
            }
            if (id==0)
            {
                return BadRequest();
            }
            await _laptopRepository.UpdateAsync(updateLaptop);
            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteLaptop(int id)
        {
            var model = await _laptopRepository.GetAsync(u => u.Id == id);
            if (model ==null)
            {
                return BadRequest();
            }
             _laptopRepository.Delete(model);
            return Ok();

        }
    }
}
