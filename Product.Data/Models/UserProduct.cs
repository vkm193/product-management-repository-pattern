using System;
using System.Collections.Generic;
using System.Text;

namespace Product.Data.Models
{
    public class UserProduct
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid ProductId { get; set; }
        public bool IsOrdered { get; set; }
        public DateTime? OrderedOn { get; set; }
        public bool IsDeleted { get; set; }

        public Products Product { get; set; }
        public Users User { get; set; }

    }
}
