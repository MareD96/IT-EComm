using AutoMapper;
using IT_EComm.Models;
using IT_EComm.Models.DTO;
using IT_EComm.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IT_EComm.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LaptopImagesController : ControllerBase
    {
        private readonly ILaptopImagesRepository _laptopImagesRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        private readonly ILaptopRepository _laptopRepository;
        protected APIResponse _response;
        public LaptopImagesController(ILaptopImagesRepository laptopImagesRepository,IMapper mapper,ILogger logger,ILaptopRepository laptopRepository)
        {
            _laptopImagesRepository = laptopImagesRepository;
            _mapper = mapper;
            _logger = logger;
            _laptopRepository = laptopRepository;
            _response = new();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status502BadGateway)]
        public async Task<ActionResult<APIResponse>> GetAllLaptopImages()
        {
            _logger.LogInformation("Calling GetAllLaptopImages HTTP GET");
            try
            {
                var models = await _laptopImagesRepository.GetAllAsync();
                _response.StatusCode= System.Net.HttpStatusCode.OK;
                
                _response.Result = _mapper.Map<List<LaptopImagesDTO>>(models);
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
        
        [HttpGet("{id:int}", Name = "GetLaptopImage")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        //Returns one image accordint to the id
        public async Task<ActionResult<APIResponse>> GetLaptopImage(int id)
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

                var foundImage = await _laptopImagesRepository.GetAsync(x => x.Id == id);
                if (foundImage == null)
                {
                    _logger.LogWarning("Model not found");
                    _response.IsSuccess = false;
                    _response.StatusCode = System.Net.HttpStatusCode.NotFound;
                    _response.ErrorMessagess = new List<string>() { "Laptop images don't exsits in database!" };
                }
                _logger.LogInformation("Everything run successfull");
                _response.StatusCode = System.Net.HttpStatusCode.OK;
                _response.Result = _mapper.Map<LaptopImagesDTO>(foundImage);
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

        [HttpGet("{laptopid:int}", Name = "GetAllLaptopImages")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        //TOBEDONE
        public async Task<ActionResult<APIResponse>> GetAllLaptopImages(int laptopid)
        {
            _logger.LogInformation("Calling GetLaptop by Id HTTP GET");
            try
            {
                if (laptopid == 0)
                {
                    _logger.LogWarning("Id is 0 or not sent in query");
                    _response.IsSuccess = false;
                    _response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                    _response.ErrorMessagess = new List<string>() { "Bad input data!" };
                    return _response;
                }

                var foundLaptopImages = await _laptopImagesRepository.GetLapTopImages(laptopid);
                if (foundLaptopImages == null)
                {
                    _logger.LogWarning("Model not found");
                    _response.IsSuccess = false;
                    _response.StatusCode = System.Net.HttpStatusCode.NotFound;
                    _response.ErrorMessagess = new List<string>() { "Laptop images don't exsits in database!" };
                }
                _logger.LogInformation("Everything run successfull");
                _response.StatusCode = System.Net.HttpStatusCode.OK;
                _response.Result = _mapper.Map<List<LaptopImagesDTO>>(foundLaptopImages);
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
        public async Task<ActionResult<APIResponse>> CreateLaptop([FromBody] CreateLaptopImagesDTO createImageLaptop)
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
                if (await _laptopRepository.GetAsync(u=>u.Id==createImageLaptop.LaptopId)==null)
                {
                    _logger.LogWarning("Cannot find the laptop");
                    _response.IsSuccess = false;
                    _response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                    _response.ErrorMessagess = new List<string>() {"Cannot find the laptop!" };
                    return _response;
                }
                if ((await _laptopImagesRepository.GetAsync(u => u.ImageURL == createImageLaptop.ImageURL) != null)||(await _laptopImagesRepository.GetAsync(u=>u.Paths ==createImageLaptop.Paths)!=null))
                {
                    _logger.LogWarning("Found same model in DB");
                    _response.IsSuccess = false;
                    _response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                    _response.ErrorMessagess = new List<string>() { "This image of laptop already exists in databas!" };
                    return _response;
                }
                if (createImageLaptop == null)
                {
                    _logger.LogWarning("Model not found");
                    _response.IsSuccess = false;
                    _response.StatusCode = System.Net.HttpStatusCode.NotFound;
                    _response.ErrorMessagess = new List<string>() { "NOT FOUND model" };
                    return _response;
                }
                _logger.LogInformation("Everything run successfull");
                var modelToSave = _mapper.Map<LaptopImages>(createImageLaptop);
                await _laptopImagesRepository.CreateAsync(modelToSave);
                _response.StatusCode = System.Net.HttpStatusCode.Created;
                _response.Result = _mapper.Map<LaptopImagesDTO>(modelToSave);
                return CreatedAtRoute("GetLaptopImage", new { id = modelToSave.Id }, _response.Result);
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
        public async Task<ActionResult<APIResponse>> UpdateLaptopImage(int id,[FromBody] UpdateLaptopImagesDTO updateLaptopImagesDTO)
        {
            _logger.LogInformation("Calling UpdateLaptopImage HTTP PUT");
            try
            {
                if (updateLaptopImagesDTO == null || id != updateLaptopImagesDTO.Id)
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
                var modelToSave = _mapper.Map<LaptopImages>(updateLaptopImagesDTO);
                await _laptopImagesRepository.UpdateAsync(modelToSave);
                _response.Result = _mapper.Map<LaptopImagesDTO>(modelToSave);
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
        public async Task<ActionResult<APIResponse>> DeleteLaptopImage(int id)
        {
            _logger.LogInformation("Calling DeleteLaptop HTTP DELETE");
            try
            {
                var modelToDelete = await _laptopImagesRepository.GetAsync(u => u.Id == id);
                if (modelToDelete == null)
                {
                    _logger.LogWarning("Cannont find this model by Id");
                    _response.IsSuccess = false;
                    _response.StatusCode = System.Net.HttpStatusCode.NotFound;
                    _response.ErrorMessagess = new List<string>() { "Cannot find this Id" };
                    return _response;
                }
                _logger.LogInformation("Everything run successfull");
                _laptopImagesRepository.Delete(modelToDelete);
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
