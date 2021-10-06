using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JS.BILL
{
    class InvoiceBLL
    {
        public int invoiceNo { get; set; }
        public int cashierId { get; set; }
        public int dealer_customerId { get; set; } 
        public decimal grandTotal { get; set; }
        public DateTime trasaction_date { get; set; }
        public decimal vat { get; set; }
        public decimal discount { get; set; }
        public decimal payment { get; set; }
        public decimal change { get; set; }
        public string type { get; set; }
        public DataTable transaction { get; set; }
    }
}
