using AutoMapper;
using IT_EComm.DataAccess;
using IT_EComm.Models;
using IT_EComm.Models.DTO;
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
        private string secretKey;
        public UserRepository(AppDbContext appDbContext,IMapper mapper,IConfiguration configuration)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
            secretKey = configuration.GetValue<string>("APISetting:Secret");
        }
        public bool isUniqueUser(string username)
        {
            var findUser = _appDbContext.User.FirstOrDefault(x=>x.UserName == username);
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
            var user = _appDbContext.User.FirstOrDefault(u=>u.UserName.ToLower()==loginRequestDTO.UserName.ToLower() && u.Password==loginRequestDTO.Password);
            if (user==null)
            {
                return null;
            }
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secretKey);
            var tokenDecriptor = new SecurityTokenDescriptor()
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString()),
                    new Claim(ClaimTypes.Role, user.Role)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials= new(new SymmetricSecurityKey(key),SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateJwtSecurityToken(tokenDecriptor);
            LoginResponseDTO loginResponseDTO = new()
            {
                Token = tokenHandler.WriteToken(token),
                User = _mapper.Map<UserDTO>(user)
            };
            return loginResponseDTO;
        }

        public async Task<UserDTO> Register(RegisterationRequestDTO registerationRequestDTO)
        {
            var user = _mapper.Map<LocalUser>(registerationRequestDTO);
            _appDbContext.User.Add(user);
            await _appDbContext.SaveChangesAsync();
            return _mapper.Map<UserDTO>(user);

        }
    }
}
