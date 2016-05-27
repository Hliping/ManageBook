using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ManageBook.DAL;
using ManageBook.Modle;
using System.Data;

namespace ManageBook.BLL
{
    public class BLLPlanBook
    {
        private DALPlanBook planbook = new DALPlanBook();
        public void InsertPlanBook(PlanBook plan) 
        {
            planbook.InsertPlanBook(plan);
        }

       // public List<PlanBook> DelectPlanBook()
       // {
       //     return planbook.DelectPlanBook();
        //}

        public DataSet PlanBookinfo()  //多表联合查询
        {
            return planbook.PlanBookinfo();
        }
        public void DeletePlanBook(string isbn)
        {
            planbook.DeletePlanBook(isbn);
        }

        public void UpdatePlanBook(PlanBook plan, string isbn)   //删除预定教材
        {
            planbook.UpdatePlanBook(plan, isbn);
        }
    }
}
