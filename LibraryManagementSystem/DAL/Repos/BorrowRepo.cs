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
    internal class BorrowRepo: IRepository<Borrow>
    {
        LibraryContext db;

        public BorrowRepo(LibraryContext db)
        {
            this.db = db;
        }

        public bool Create(Borrow b)
        {
            db.Borrows.Add(b);
            return db.SaveChanges() > 0;
        }

        public List<Borrow> Get()
        {
            return db.Borrows.ToList();
        }

        public Borrow Get(int id)
        {
            return db.Borrows.Find(id);
        }

        public bool Update(Borrow b)
        {
            var ex = Get(b.Id);
            db.Entry(ex).CurrentValues.SetValues(b);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var ex = Get(id);
            db.Borrows.Remove(ex);
            return db.SaveChanges() > 0;
        }
    }
}
