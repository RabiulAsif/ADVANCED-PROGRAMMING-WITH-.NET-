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
    public class NotificationService
    {
        DataAccessFactory factory;

        public NotificationService(DataAccessFactory factory)
        {
            this.factory = factory;
        }

        public List<NotificationDTO> Get()
        {
            var data = factory.NotificationData().Get();
            var mapper = MapperConfig.GetMapper();
            return mapper.Map<List<NotificationDTO>>(data);
        }

        public bool Create(string message)
        {
            Notification n = new Notification()
            {
                Message = message
            };

            return factory.NotificationData().Create(n);
        }
    }
}
