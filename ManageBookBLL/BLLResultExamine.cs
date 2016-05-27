using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ManageBook.DAL;
using ManageBook.Modle;

namespace ManageBook.BLL
{
    public class BLLResultExamine
    {
        private DALResultExamine dalrt = new DALResultExamine();
        public int UpdateBookStock(string isbn)
        {
            return dalrt.UpdateBookStock(isbn);
        }
        public void deleteStockBookID(string isbn)
        {
            dalrt.deleteStockBookID(isbn);
        }
    }
}
