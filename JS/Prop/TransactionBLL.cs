using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JS.BILL
{
    class TransactionBLL
    {
        public int transactionNo { get; set; }
        public int invoiceNo { get; set; }
        public int itemId { get; set; }
        public decimal price { get; set; }
        public decimal qty { get; set; }
        public decimal total { get; set; }
        public DateTime added_date { get; set; }
        public int dealer_customerId { get; set; }
    }
}
