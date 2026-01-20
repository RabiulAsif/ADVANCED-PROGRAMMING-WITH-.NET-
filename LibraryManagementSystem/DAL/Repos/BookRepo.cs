using DAL.EF;
using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class BookRepo: IRepository<Book>
    {
        LibraryContext db;

        public BookRepo(LibraryContext db)
        {
            this.db = db;
        }

        public bool Create(Book b)
        {
            db.Books.Add(b);
            return db.SaveChanges() > 0;
        }

        public List<Book> Get()
        {
            return db.Books.ToList();
        }

        public Book Get(int id)
        {
            return db.Books.Find(id);
        }

        public bool Update(Book b)
        {
            var ex = Get(b.Id);
            db.Entry(ex).CurrentValues.SetValues(b);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var ex = Get(id);
            db.Books.Remove(ex);
            return db.SaveChanges() > 0;
        }
    }
}
