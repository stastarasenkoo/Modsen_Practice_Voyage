using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Voyage.DataAccess.Model
{
    internal class Role
    {
        [Key]
        public int RoleId { get; set; } //primary key 
        public string Name { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
