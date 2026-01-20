using DAL.EF;
using DAL.EF.Models;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class CategoryRepo: IRepository<Category>, ICategoryFeature
    {
        LibraryContext db;

        public CategoryRepo(LibraryContext db)
        {
            this.db = db;
        }

        public bool Create(Category c)
        {
            db.Categories.Add(c);
            return db.SaveChanges() > 0;
        }

        public List<Category> Get()
        {
            return db.Categories.ToList();
        }

        public Category Get(int id)
        {
            return db.Categories.Find(id);
        }

        public bool Update(Category c)
        {
            var ex = Get(c.Id);
            db.Entry(ex).CurrentValues.SetValues(c);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var ex = Get(id);
            db.Categories.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public List<Category> GetWithBooks()
        {
            return db.Categories.Include(c => c.Books).ToList();
        }

        public Category GetWithBooks(int id)
        {
            return db.Categories.Include(c => c.Books).SingleOrDefault(c => c.Id == id);
        }
        public Category FindByName(string name)
        {
            var cat = (from c in db.Categories
                       where c.Name.Contains(name)
                       select c).SingleOrDefault();
            return cat;
        }

        public Category FindByNameWithBooks(string name)
        {
            var cat = db.Categories.Include(ct => ct.Books)
                      .SingleOrDefault(c => c.Name.Contains(name));
            return cat;
        }
    }
}
