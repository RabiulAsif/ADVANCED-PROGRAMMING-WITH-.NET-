using DAL.Interfaces;
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
    public class CategoryService
    {
        DataAccessFactory factory;

        public CategoryService(DataAccessFactory factory)
        {
            this.factory = factory;
        }

        public List<CategoryDTO> Get()
        {
            var data = factory.CategoryData().Get();
            var mapper = MapperConfig.GetMapper();
            return mapper.Map<List<CategoryDTO>>(data);
        }

        public CategoryDTO Get(int id)
        {
            var data = factory.CategoryData().Get(id);
            var mapper = MapperConfig.GetMapper();
            return mapper.Map<CategoryDTO>(data);
        }

        public bool Create(CategoryDTO c)
        {
            var mapper = MapperConfig.GetMapper();
            var data = mapper.Map<Category>(c);
            return factory.CategoryData().Create(data);
        }

        public bool Update(CategoryDTO c)
        {
            var mapper = MapperConfig.GetMapper();
            var data = mapper.Map<Category>(c);
            return factory.CategoryData().Update(data);
        }

        public bool Delete(int id)
        {
            return factory.CategoryData().Delete(id);
        }

        public List<CategoryBookDTO> GetWithBooks()
        {
            var data = factory.CategoryFeatures().GetWithBooks();
            var mapper = MapperConfig.GetMapper();
            return mapper.Map<List<CategoryBookDTO>>(data);
        }
        public CategoryDTO FindByName(string name)
        {
            var data = factory.CategoryFeatures().FindByName(name);
            var mapper = MapperConfig.GetMapper();
            return mapper.Map<CategoryDTO>(data);
        }

        public CategoryDTO FindByNameWithBooks(string name)
        {
            var data = factory.CategoryFeatures().FindByNameWithBooks(name);
            var mapper = MapperConfig.GetMapper();
            return mapper.Map<CategoryDTO>(data);
        }

    }
}
