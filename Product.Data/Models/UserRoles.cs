using System;
using System.Collections.Generic;
using System.Text;

namespace Product.Data.Models
{
    public class UserRoles
    {
        public Guid Id { get; set; }
        public string RoleName { get; set; }

        public ICollection<Users> Users { get; set; }
    }
}
