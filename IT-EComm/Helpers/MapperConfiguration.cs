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
        }
    }
}
