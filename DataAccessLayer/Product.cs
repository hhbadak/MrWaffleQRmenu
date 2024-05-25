using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string Price { get; set; }
        public int CategoryID { get; set; }
        public string Category { get; set; }
        public bool BestSeller { get; set; }
    }
}
