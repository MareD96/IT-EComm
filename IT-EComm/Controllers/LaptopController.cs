using AutoMapper;
using IT_EComm.Models;
using IT_EComm.Models.DTO;
using IT_EComm.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IT_EComm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LaptopController : ControllerBase
    {
        private readonly ILaptopRepository _laptopRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        protected APIResponse _response;
        public LaptopController(ILaptopRepository laptopRepository,IMapper mapper,ILogger logger)
        {
            _laptopRepository = laptopRepository;
            _mapper = mapper;
            _logger = logger;
            _response = new();
        }

        [HttpGet]

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status502BadGateway)]
        public async Task<ActionResult<APIResponse>> GetLaptops()
        {
            _logger.LogInformation("Calling GetAllLaptops HTTP GET");
            try
            {
                var models = await _laptopRepository.GetAllAsync();
                _response.StatusCode= System.Net.HttpStatusCode.OK;
                
                _response.Result = _mapper.Map<List<LaptopDTO>>(models);
                _logger.LogInformation("Everything ran sucessfull");
                return Ok(_response);
               
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"There is excetpion {ex.Message}");
                _response.IsSuccess = false;
                _response.StatusCode = System.Net.HttpStatusCode.BadGateway;
                _response.ErrorMessagess = new List<string>
                {
                    ex.Message.ToString()
                };
               
            }
            
            return _response;
        }
        [HttpGet("{id:int}", Name = "GetLaptop")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetLaptops(int id)
        {
            _logger.LogInformation("Calling GetLaptop by Id HTTP GET");
            try
            {
                if (id == 0)
                {
                    _logger.LogWarning("Id is 0 or not sent in query");
                    _response.IsSuccess = false;
                    _response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                    _response.ErrorMessagess = new List<string>() { "Bad input data!" };
                    return _response;
                }

                var foundLaptop = await _laptopRepository.GetAsync(x => x.Id == id);
                if (foundLaptop == null)
                {
                    _logger.LogWarning("Model not found");
                    _response.IsSuccess = false;
                    _response.StatusCode = System.Net.HttpStatusCode.NotFound;
                    _response.ErrorMessagess = new List<string>() { "Laptop don't exsits in database!" };
                }
                _logger.LogInformation("Everything run successfull");
                _response.StatusCode = System.Net.HttpStatusCode.OK;
                _response.Result = _mapper.Map<LaptopDTO>(foundLaptop);
                return _response;
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"There is excetpion {ex.Message}");
                _response.IsSuccess = false;
                _response.StatusCode = System.Net.HttpStatusCode.BadGateway;
                _response.ErrorMessagess = new List<string>
                {
                    ex.Message.ToString()
                };
            }

            return _response;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> CreateLaptop([FromBody] CreateLaptopDTO createLaptop)
        {
            _logger.LogInformation("Calling CreateLaptop HTTP POST");
            try
            {
                if (!ModelState.IsValid)
                {
                    _logger.LogWarning("Model state is not Valid");
                    _response.IsSuccess = false;
                    _response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                    _response.ErrorMessagess = new List<string>() { "Wrong input data for model" };
                    return _response;
                }
                if (await _laptopRepository.GetAsync(u => u.Model == createLaptop.Model) != null)
                {
                    _logger.LogWarning("Found same model in DB");
                    _response.IsSuccess = false;
                    _response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                    _response.ErrorMessagess = new List<string>() { "This model of laptop already exists in databas!" };
                    return _response;
                }
                if (createLaptop == null)
                {
                    _logger.LogWarning("Model not found");
                    _response.IsSuccess = false;
                    _response.StatusCode = System.Net.HttpStatusCode.NotFound;
                    _response.ErrorMessagess = new List<string>() { "NOT FOUND model" };
                    return _response;
                }
                _logger.LogInformation("Everything run successfull");
                var modelToSave = _mapper.Map<Laptop>(createLaptop);
                await _laptopRepository.CreateAsync(modelToSave);
                _response.StatusCode = System.Net.HttpStatusCode.Created;
                _response.Result = _mapper.Map<LaptopDTO>(modelToSave);
                return CreatedAtRoute("GetLaptop", new { id = createLaptop.Id }, createLaptop);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"There is excetpion {ex.Message}");
                _response.IsSuccess = false;
                _response.StatusCode = System.Net.HttpStatusCode.BadGateway;
                _response.ErrorMessagess = new List<string>
                {
                    ex.Message.ToString()
                };
            }
            return _response;

        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> UpdateLaptop(int id,[FromBody] UpdateLaptopDTO updateLaptop)
        {
            _logger.LogInformation("Calling UpdateLaptop HTTP PUT");
            try
            {
                if (updateLaptop == null || id != updateLaptop.Id)
                {
                    _logger.LogWarning("Model in body is null or id sent in query and in the body are diffrent");
                    _response.IsSuccess = false;
                    _response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                    _response.ErrorMessagess = new List<string>() { "Wrong input data for model" };
                    return _response;
                }
                if (id == 0)
                {
                    _logger.LogWarning("Id is 0 or not sent in query");
                    _response.IsSuccess = false;
                    _response.StatusCode = System.Net.HttpStatusCode.NotFound;
                    _response.ErrorMessagess = new List<string>() { "Cannot find this Id" };
                    return _response;
                }
                _logger.LogInformation("Everything run successfull");
                var modelToSave = _mapper.Map<Laptop>(updateLaptop);
                await _laptopRepository.UpdateAsync(modelToSave);
                _response.Result = _mapper.Map<LaptopDTO>(modelToSave);
                _response.StatusCode = System.Net.HttpStatusCode.OK;

            }
            catch (Exception ex)
            {
                _logger.LogInformation($"There is excetpion {ex.Message}");
                _response.IsSuccess = false;
                _response.StatusCode = System.Net.HttpStatusCode.BadGateway;
                _response.ErrorMessagess = new List<string>
                {
                    ex.Message.ToString()
                };
            }
            return _response;
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> DeleteLaptop(int id)
        {
            _logger.LogInformation("Calling DeleteLaptop HTTP DELETE");
            try
            {
                var modelToDelete = await _laptopRepository.GetAsync(u => u.Id == id);
                if (modelToDelete == null)
                {
                    _logger.LogWarning("Cannont find this model by Id");
                    _response.IsSuccess = false;
                    _response.StatusCode = System.Net.HttpStatusCode.NotFound;
                    _response.ErrorMessagess = new List<string>() { "Cannot find this Id" };
                    return _response;
                }
                _logger.LogInformation("Everything run successfull");
                _laptopRepository.Delete(modelToDelete);
                _response.StatusCode = System.Net.HttpStatusCode.OK;
                return _response;
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"There is excetpion {ex.Message}");
                _response.IsSuccess = false;
                _response.StatusCode = System.Net.HttpStatusCode.BadGateway;
                _response.ErrorMessagess = new List<string>
                {
                    ex.Message.ToString()
                };
            }
            return _response;

        }
    }
}
