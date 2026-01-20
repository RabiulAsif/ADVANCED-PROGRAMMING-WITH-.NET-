using BLL.DTOs;
using DAL;
using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class UserService
    {
        DataAccessFactory factory;
        public UserService(DataAccessFactory factory)
        {
            this.factory = factory;
        }
        public List<UserDTO> Get()
        {
            var data = factory.UserData().Get();
            var mapper = MapperConfig.GetMapper();
            return mapper.Map<List<UserDTO>>(data);
        }
        public UserDTO Get(int id)
        {
            var data = factory.UserData().Get(id);
            var mapper = MapperConfig.GetMapper();
            return mapper.Map<UserDTO>(data);
        }
        public bool Create(UserDTO u)
        {
            var mapper = MapperConfig.GetMapper();
            var data = mapper.Map<User>(u);
            return factory.UserData().Create(data);
        }
        public bool Update(UserDTO u)
        {
            var mapper = MapperConfig.GetMapper();
            var data = mapper.Map<User>(u);
            return factory.UserData().Update(data);
        }
        public bool Delete(int id)
        {
            return factory.UserData().Delete(id);
        }
    }
}
