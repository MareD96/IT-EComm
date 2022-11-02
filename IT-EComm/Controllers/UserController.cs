using AutoMapper;
using IT_EComm.Models;
using IT_EComm.Models.DTO;
using IT_EComm.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IT_EComm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        protected APIResponse _response;

        public UserController(IUserRepository userRepository, IMapper mapper,ILogger logger)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _logger = logger;
            _response = new APIResponse();
        }
        //Register
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost("Register")]
        public async Task<ActionResult<APIResponse>> Register([FromBody]RegisterationRequestDTO registerationRequestDTO)
        {
            _logger.LogInformation("Calling Register HTTP POST");
            try
            {
                bool userExists = _userRepository.isUniqueUser(registerationRequestDTO.UserName);
                if (!userExists)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                    _response.ErrorMessagess.Add("Username already exists ");
                    return BadRequest(_response);
                }
                var user = await _userRepository.Register(registerationRequestDTO);
                if (user == null)
                {
                    _logger.LogInformation("Failed to register user!");
                    _response.IsSuccess = false;
                    _response.StatusCode = System.Net.HttpStatusCode.NotFound;
                    _response.ErrorMessagess.Add("Failed to register user");
                    return NotFound(_response);
                }
                _logger.LogInformation("Everything ran sucessfull");
                _response.IsSuccess = true;
                _response.StatusCode = System.Net.HttpStatusCode.OK;
                _response.Result = user;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _logger.LogInformation("There is exception");
                _response.IsSuccess = false;
                _response.StatusCode = System.Net.HttpStatusCode.BadRequest;

                _response.ErrorMessagess = new List<string>
                {
                    ex.Message.ToString()
                };
                return StatusCode(500, _response);
            }

        }
        //Login
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost("Login")]
        public async Task<ActionResult<APIResponse>> Login([FromBody]LoginRequestDTO loginRequestDTO)
        {
            _logger.LogInformation("Calling Login HTTP POST");
            try
            {
                var loginResponse = await _userRepository.Login(loginRequestDTO);
                if (loginResponse.User == null || string.IsNullOrEmpty(loginResponse.Token))
                {
                    _logger.LogInformation("Bad password or username!");
                    _response.IsSuccess = false;
                    _response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                    _response.ErrorMessagess.Add("UserName or password isn't correct!");
                    return NotFound(_response);
                }
                _logger.LogInformation("Everything ran sucessfull");
                _response.IsSuccess = true;
                _response.StatusCode = System.Net.HttpStatusCode.OK;
                _response.Result = loginResponse;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _logger.LogInformation("There is exception in the code!");
                _response.IsSuccess = false;
                _response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                _response.ErrorMessagess = new List<string>
                {
                    ex.Message.ToString()
                };
                return StatusCode(500,_response);
            }

        }
    }
}
