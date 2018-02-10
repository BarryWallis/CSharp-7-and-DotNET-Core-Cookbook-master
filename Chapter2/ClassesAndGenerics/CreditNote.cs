using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassesAndGenerics
{
    public class CreditNote
    {
        public int ID { get; set; }
        public decimal TotalValue { get; set; }
        public int LineNumber { get; set; }
        public string StockItem { get; set; }
        public decimal ItemPrice { get; set; }
        public int Quantity { get; set; }
    }
}
