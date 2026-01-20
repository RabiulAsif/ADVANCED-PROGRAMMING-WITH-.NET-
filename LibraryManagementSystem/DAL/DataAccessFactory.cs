using DAL.EF;
using DAL.EF.Models;
using DAL.Interfaces;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataAccessFactory
    {
        LibraryContext db;

        public DataAccessFactory(LibraryContext db)
        {
            this.db = db;
        }

        public IRepository<Category> CategoryData()
        {
            return new CategoryRepo(db);
        }

        public ICategoryFeature CategoryFeatures()
        {
            return new CategoryRepo(db);
        }

        public IRepository<Book> BookData()
        {
            return new BookRepo(db);
        }

        public IRepository<User> UserData()
        {
            return new UserRepo(db);
        }

        public IRepository<Borrow> BorrowData()
        {
            return new BorrowRepo(db);
        }

        public INotificationRepo NotificationData()
        {
            return new NotificationRepo(db);
        }
    }
}
