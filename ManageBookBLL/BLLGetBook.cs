using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ManageBook.DAL;
using ManageBook.Modle;

namespace ManageBook.BLL
{
    public class BLLGetBook
    {
        private DALGetBook dalgb = new DALGetBook();
        public void UpdateGetBook(GetBook gb)
        {
            dalgb.UpdateGetBook(gb);
        }
    }
}
