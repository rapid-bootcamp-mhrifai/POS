using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.ViewModel.DTO
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string CompanyName { get; set; }
        public string CategoryName { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
        public long UnitInStock { get; set; }
        public long UnitInOrder { get; set; }
        public long ReorderLevel { get; set; }
        public bool Discontinued { get; set; }

    }
}
