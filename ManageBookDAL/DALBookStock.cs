using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ManageBook.Modle;
using System.Data;
using System.Data.SqlClient;

namespace ManageBook.DAL
{
    public class DALBookStock
    {
        public void UpdateBookStock(BookStock bookstock)
        {
            string sql = "Update BookStock set ArriveQuantity=@ArriveQuantity,NoArriveQuantity=@NoArriveQuantity,NetPrice=@NetPrice,Discount=@Discount,Arrived='true' where BookStock.PlanBookID = (select PlanBook.PlanBookID from PlanBook where ISBN=@ISBN)";
            SqlParameter[] parameter = { new SqlParameter("@ArriveQuantity", SqlDbType.Int),
                                           new SqlParameter("@NoArriveQuantity",SqlDbType.Int),
                                         new SqlParameter("@NetPrice",SqlDbType.Float),
                                         new SqlParameter("@Discount",SqlDbType.Float),
                                         new SqlParameter("@ISBN",SqlDbType.VarChar)
                                        };
            parameter[0].Value = bookstock.ArriveQuantity;
            parameter[1].Value = bookstock.NoArriveQuantity;
            parameter[2].Value = bookstock.NetPrice;
            parameter[3].Value = bookstock.Discount;
            parameter[4].Value = bookstock.ISBN;
            DBHelpers.UpdateInfo(sql, parameter);
            
        }
        public DataSet SelectBookStock()
        {
            string sql = "SELECT  PlanBook.BookName as '教材名称', PlanBook.ISBN as 'ISBN码', PlanBook.Author as '作者', PlanBook.Publish as '出版社', PlanBook.Price as '标价',BookStock.NetPrice as '实价',PlanBook.BookTotalNum as '订购数量', BookStock.ArriveQuantity as '库存数量',BookStock.NoArriveQuantity as '未到数量'  FROM  BookStock INNER JOIN PlanBook ON BookStock.PlanBookID = PlanBook.PlanBookID where BookStock.Arrived='true'";
            return DBHelpers.GetAllInfoToDataSet(sql);
        }
        public DataSet NoArriveBook() 
        {
            string sql = "SELECT PlanBook.BookName as '教材名称', PlanBook.ISBN as 'ISBN码', PlanBook.Author as '作者', PlanBook.Publish as '出版社', PlanBook.Price as '标价', PlanBook.BookTotalNum as '订购数量', BookStock.ArriveQuantity as '已到数量',BookStock.NoArriveQuantity as '未到数量' FROM PlanBook INNER JOIN BookStock ON PlanBook.PlanBookID = BookStock.PlanBookID";
            return DBHelpers.GetAllInfoToDataSet(sql);
        }
    }
}
