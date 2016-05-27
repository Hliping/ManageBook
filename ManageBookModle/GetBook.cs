using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ManageBook.Modle
{
    public class GetBook:PlanBook
    {
        public int GetBookID { get; set; }
        public string Signer { get; set; }
        public string SignerIdentity { get; set; }
        public string SignerPhone { get; set; }
        public string GetBookRemsrks { get; set; }
        public int GetBookNum { get; set; }
    }
}
