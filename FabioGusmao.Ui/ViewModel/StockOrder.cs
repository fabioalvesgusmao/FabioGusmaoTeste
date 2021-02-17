using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FabioGusmao.Ui.ViewModel
{
    public class StockOrder
    {
        public int? Id { get; set; }
        public DateTime? DateTime { get; set; }
        public string OperationType { get; set; }
        public string Ticker { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public int? Account { get; set; }
    }
}
