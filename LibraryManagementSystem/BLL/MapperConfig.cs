using AutoMapper;
using BLL.DTOs;
using DAL.EF.Models;

namespace BLL
{
    public class MapperConfig
    {
        static MapperConfiguration cfg = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<Category, CategoryDTO>().ReverseMap();

            cfg.CreateMap<Category, CategoryBookDTO>().ReverseMap();

            cfg.CreateMap<Book, BookDTO>().ReverseMap();

            cfg.CreateMap<User, UserDTO>().ReverseMap();

            cfg.CreateMap<Borrow, BorrowDTO>().ReverseMap();

            cfg.CreateMap<Notification, NotificationDTO>().ReverseMap();
        });

        public static Mapper GetMapper()
        {
            return new Mapper(cfg);
        }
    }
}
