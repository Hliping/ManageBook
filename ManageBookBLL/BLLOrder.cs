using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ManageBook.DAL;
using System.Data;


namespace ManageBook.BLL
{
    public class BLLOrder
    {
        private DALOrder dalo = new DALOrder();
        private DataTable dt;
        public DataTable GetAllOrder(int index,string info)
        {
            dt = dalo.GetAllOrder(index, info).Tables[0];
            return dt;
        }
    }
}
