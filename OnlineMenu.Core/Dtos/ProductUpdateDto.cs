using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMenu.Core.Dtos
{
    public class ProductUpdateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }

        public string? Image { get; set; }

        public string? Info { get; set; }
        public int UserId { get; set; }
        public int CategoryId { get; set; }

        public Category? Category { get; set; }
        public User? User { get; set; }
    }
}
