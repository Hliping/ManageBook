using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ManageBook.Modle
{
    public class ExamineBook:PlanBook
    {
        public bool Examine { get; set; }
        public string OrderBookRemarks { get; set; }
    }
}
