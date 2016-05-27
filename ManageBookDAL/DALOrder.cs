using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.SqlClient;
using ManageBook.Modle;

namespace ManageBook.DAL
{
    public class DALOrder
    {
        private DataSet ds;
        public DataSet GetAllOrder(int index, string info)
        {
            using (SqlConnection conn = new SqlConnection(DBHelpers.Connection))
            {
                SqlCommand scm = new SqlCommand();
                StringBuilder sql = new StringBuilder("SELECT  PlanBook.BookName as '教材名称', PlanBook.ISBN as 'ISBN码', PlanBook.Author as '作者', PlanBook.Publish as '出版社', PlanBook.Price as '标价', PlanBook.BookTotalNum as '数量' FROM  BookStock INNER JOIN PlanBook ON BookStock.PlanBookID = PlanBook.PlanBookID where 1=1");
                scm.Connection = conn;
                if (index == 0)
                {
                    scm.CommandText = sql.ToString();
                }
                if (index == 1)
                {
                    sql.Append(" and BookName like @BookName");
                    scm.CommandText = sql.ToString();
                    scm.Parameters.AddWithValue("@BookName", info);
                }
                if (index == 2)
                {
                    sql.Append(" and ISBN like @ISBN");
                    scm.CommandText = sql.ToString();
                    scm.Parameters.AddWithValue("@ISBN", info);
                }
                if (index == 3)
                {
                    sql.Append(" and Author like @Author");
                    scm.CommandText = sql.ToString();
                    scm.Parameters.AddWithValue("@Author", info);
                }
                if (index == 4)
                {
                    sql.Append(" and Publish like @Publish");
                    scm.CommandText = sql.ToString();
                    scm.Parameters.AddWithValue("@Publish", info);
                }
                if (index == 5)
                {
                    sql.Append(" and BookStock.Arrived='false'");
                    scm.CommandText = sql.ToString();
                }
                SqlDataAdapter sda = new SqlDataAdapter();
                sda.SelectCommand = scm;
                ds = new DataSet();

                try
                {
                    sda.Fill(ds);
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return ds;
        }
    }
}
