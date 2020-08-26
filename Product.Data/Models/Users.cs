using System;
using System.Collections.Generic;
using System.Text;

namespace Product.Data.Models
{
    public class Users
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }
        public string Password { get; set; }
        public Guid UserRoleId { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public bool IsActive { get; set; }

        public UserRoles UserRole { get; set; }
        public ICollection<Products> Products { get; set; }
        public ICollection<Products> Products1 { get; set; }
        public ICollection<UserProduct> UserProducts { get; set; }
    }
}
