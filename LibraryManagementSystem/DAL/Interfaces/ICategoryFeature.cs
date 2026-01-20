using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface ICategoryFeature
    {
        List<Category> GetWithBooks();
        Category GetWithBooks(int id);
        Category FindByName(string name);
        Category FindByNameWithBooks(string name);
    }
}
