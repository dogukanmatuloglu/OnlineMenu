using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMenu.Core.Dtos
{
    public class ProductDto
    {
       
        public string Name { get; set; }
        public double Price { get; set; }

        public string? Image { get; set; }

        public string? Info { get; set; }
      
       
    }
}
