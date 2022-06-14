using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Voyage.DataAccess.Model
{
    internal class User
    {
        [Key]
        public int UserId { get; set; } //primary key
        public int RoleId { get; set; } //foreign key
        public Role Role { get; set; } //navigational property
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string HashPassword { get; set; }

        public Passenger Passenger { get; set; }
        public Driver Driver { get; set; }
    }
}
