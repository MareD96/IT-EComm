using AutoMapper;
using IT_EComm.Models;
using IT_EComm.Models.DTO;

namespace IT_EComm.Helpers
{
    public class MapperConfiguration:Profile
    {
        public MapperConfiguration()
        {
            CreateMap<Laptop, LaptopDTO>().ReverseMap();
            CreateMap<Laptop, CreateLaptopDTO>().ReverseMap();
            CreateMap<Laptop, UpdateLaptopDTO>().ReverseMap();

            CreateMap<LaptopImages, LaptopImagesDTO>().ReverseMap();
            CreateMap<LaptopImages, CreateLaptopImagesDTO>().ReverseMap();
            CreateMap<LaptopImages, UpdateLaptopImagesDTO>().ReverseMap();

            CreateMap<RegisterationRequestDTO, LocalUser>().ReverseMap();
            CreateMap<LocalUser, UserDTO>().ReverseMap();
        }
    }
}
