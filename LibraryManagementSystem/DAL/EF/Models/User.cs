using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string Role { get; set; }
        public virtual ICollection<Borrow> Borrows { get; set; }
        public virtual ICollection<Notification> Notifications { get; set; }

        public User()
        {
            Borrows = new List<Borrow>();
            Notifications = new List<Notification>();
        }
    }
}
