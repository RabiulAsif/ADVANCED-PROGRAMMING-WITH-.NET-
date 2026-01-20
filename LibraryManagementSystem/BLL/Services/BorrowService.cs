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
    public class BorrowService
    {
        DataAccessFactory factory;

        public BorrowService(DataAccessFactory factory)
        {
            this.factory = factory;
        }
       
        public List<BorrowDTO> Get()
        {
            var data = factory.BorrowData().Get();
            var mapper = MapperConfig.GetMapper();
            return mapper.Map<List<BorrowDTO>>(data);
        }
      
        public bool BorrowBook(BorrowDTO b)
        {
            var mapper = MapperConfig.GetMapper();
            var data = mapper.Map<Borrow>(b);

            data.BorrowDate = DateTime.Now;
            data.DueDate = DateTime.Now.AddDays(3);
            data.Status = "Borrowed";

            var res = factory.BorrowData().Create(data);
           
            if (res)
            {
                factory.NotificationData().Create(new Notification
                {
                    Message = "A book has been borrowed."
                });
            }

            return res;
        }
     
        public bool ReturnBook(int id)
        {
            var data = factory.BorrowData().Get(id);

            data.ReturnDate = DateTime.Now;
            data.Status = "Returned";

            bool isLate = data.ReturnDate > data.DueDate;

            var res = factory.BorrowData().Update(data);

            if (res)
            {
                var user = factory.UserData().Get(data.UserId);

                factory.NotificationData().Create(new Notification
                {
                    Message = $"{user.Name} has returned a book."
                });

                if (isLate)
                {
                    factory.NotificationData().Create(new Notification
                    {
                        Message = "Book returned late. Fine: 100 TK."
                    });
                }
            }

            return res;
        }
    }
}
