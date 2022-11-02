using AutoMapper;
using IT_EComm.DataAccess;
using IT_EComm.Models;
using IT_EComm.Models.DTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace IT_EComm.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ILogger _logger;
        private string secretKey;
        public UserRepository(AppDbContext appDbContext,IMapper mapper,IConfiguration configuration,UserManager<ApplicationUser> userManager,RoleManager<IdentityRole> roleManager, ILogger logger)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
            _userManager = userManager;
            _roleManager = roleManager;
            _logger = logger;
            secretKey = configuration.GetValue<string>("APISetting:Secret");
        }
        public bool isUniqueUser(string username)
        {
            _logger.LogInformation("Calling isUniquerUser");
            var findUser = _appDbContext.ApplicationUsers.FirstOrDefault(x=>x.UserName == username);
            if (findUser==null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO)
        {
            _logger.LogInformation("Calling Login method in User Repository");

            _logger.LogInformation("Check if user exists in db");
            var user = _appDbContext.ApplicationUsers.FirstOrDefault(u=>u.UserName.ToLower()==loginRequestDTO.UserName.ToLower());

            _logger.LogInformation("Checking password");
            bool isPasswordOk= await _userManager.CheckPasswordAsync(user,loginRequestDTO.Password);

            if (user==null || !isPasswordOk)
            {
                _logger.LogInformation("Wrong password or username");
                LoginResponseDTO loginResponse = new LoginResponseDTO()
                {

                    Token = "",
                    User = null
                };
                return loginResponse;
                
            }
            var roles = await _userManager.GetRolesAsync(user);

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secretKey);
            var tokenDecriptor = new SecurityTokenDescriptor()
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.UserName.ToString()),
                    // In future version add foreach lopp to add all roles if user have multiple roles
                    new Claim(ClaimTypes.Role, roles.FirstOrDefault())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials= new(new SymmetricSecurityKey(key),SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateJwtSecurityToken(tokenDecriptor);
            _logger.LogInformation("Generating token");
            LoginResponseDTO loginResponseDTO = new()
            {

                Token = tokenHandler.WriteToken(token),
                User = _mapper.Map<UserDTO>(user)
            };
            return loginResponseDTO;
        }

        public async Task<UserDTO> Register(RegisterationRequestDTO registerationRequestDTO)
        {
            try
            {
                var user = _mapper.Map<ApplicationUser>(registerationRequestDTO);

                var result = await _userManager.CreateAsync(user, registerationRequestDTO.Password);
                if (result.Succeeded)
                {
                    if (! _roleManager.RoleExistsAsync("admin").GetAwaiter().GetResult())
                    {
                        await _roleManager.CreateAsync(new IdentityRole("admin"));
                        await _roleManager.CreateAsync(new IdentityRole("customer"));
                    }
                    if (registerationRequestDTO.Role =="admin")
                    {
                        await _userManager.AddToRoleAsync(user, "admin");
                    }
                    else
                    {
                        await _userManager.AddToRoleAsync(user, "customer");
                    }
                    var userToReturn = _appDbContext.ApplicationUsers.FirstOrDefault(u => u.UserName == registerationRequestDTO.UserName);

                    return _mapper.Map<UserDTO>(userToReturn);
                }
                
                 
            }
            catch (Exception e)
            {
                //TO DO better logic to handler exceptions
                throw;
            }
            return new UserDTO();

        }
    }
}
