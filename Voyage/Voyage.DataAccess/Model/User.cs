using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Voyage.DataAccess
{
    internal class User
    {
        public int UserId { get; set; } //первичный ключ 
        public int RoleId { get; set; } //внешний ключ
        public Role Role { get; set; } //навигационное свойство
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string HashPassword { get; set; }
    }
}
