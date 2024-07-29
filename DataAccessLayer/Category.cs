using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Category
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public string SpecialID { get; set; }
        public string Image { get; set; }
        // Ürünlerin listesini ekleyin
        public List<Product> Products { get; set; } // Ürünleri içeren liste
    }
}
