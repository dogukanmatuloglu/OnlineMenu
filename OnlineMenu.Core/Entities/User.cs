using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMenu.Core.Entities
{
    public class User:IdentityUser
    {
        public string? Picture { get; set; }
        public string? Info { get; set; }

        public ICollection<Product>? Products { get; set; }
        public ICollection<Category>? Categories { get; set; }
    }
}
