using System;
using System.Collections.Generic;
using System.Text;

namespace Product.Data.Models
{
    public class Products
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public Decimal Price { get; set; }
        public Decimal SalePrice { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public Guid UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public bool IsActive { get; set; }

        public Users User { get; set; }
        public Users User1 { get; set; }
        public ICollection<UserProduct> UserProduct { get; set; }
    }
}
