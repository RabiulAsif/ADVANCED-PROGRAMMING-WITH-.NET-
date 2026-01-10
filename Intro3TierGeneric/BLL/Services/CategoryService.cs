using BLL.DTOs;
using DAL.EF.Models;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class CategoryService
    {
        CategoryRepo repo;
        public CategoryService(CategoryRepo repo)
        {
            this.repo = repo;
        }
        public List<CategoryDTO> Get()
        {
            var data = repo.Get();
            var mapper = MapperConfig.GetMapper();
            var ret=mapper.Map<List<CategoryDTO>>(data);
            return ret;
        }
        public CategoryDTO Get(int id)
        {
            return MapperConfig.GetMapper().Map<CategoryDTO>(repo.Get(id));
        }
        public bool Create(CategoryDTO c)
        {
            var mapper = MapperConfig.GetMapper();
            var data = mapper.Map<Category>(c);
            return repo.Create(data);
        }
        public bool Update(CategoryDTO c)
        {
            var mapper = MapperConfig.GetMapper();
            var data = mapper.Map<Category>(c);
            return repo.Update(data);
        }
        public bool Delete(int id)
        {
            return repo.Delete(id);
        }
    }
}
