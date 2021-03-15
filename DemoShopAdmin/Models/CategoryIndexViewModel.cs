using DemoShopAdmin.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoShopAdmin.Models
{
    public class CategoryIndexViewModel
    {
        public IEnumerable<Category> Categories { get; set; }
        public PageViewModel PageViewModel { get; set; }
    }
}
