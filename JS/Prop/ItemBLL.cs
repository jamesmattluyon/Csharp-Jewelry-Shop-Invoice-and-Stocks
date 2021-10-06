using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JS.BILL
{
    class ItemBLL
    {
        public int itemId { get; set; }
        public string itemName { get; set; }
        public string itemType { get; set; }
        public string itemCategory { get; set; }
        public string itemCondition { get; set; }
        public decimal itemPrice { get; set; }
        public decimal itemQuantity { get; set; }
        public DateTime added_Date { get; set; }

    }
}
