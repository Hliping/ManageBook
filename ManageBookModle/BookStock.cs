using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ManageBook.Modle
{
    public class BookStock:PlanBook
    {
        public int StockBookID { get; set; }
        //public int PlanBookID { get; set; }
        public int ArriveQuantity { get; set; }
        public int NoArriveQuantity { get; set; }
        public float NetPrice { get; set; }
        public float Discount { get; set; }
        public bool Arrived { get; set; }
    }
}
