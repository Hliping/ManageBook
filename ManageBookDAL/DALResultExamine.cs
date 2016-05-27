using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.SqlClient;
using ManageBook.Modle;

namespace ManageBook.DAL
{
    public class DALResultExamine
    {
        private int i;
        public int UpdateBookStock(string isbn)
        {
            SqlCommand scm;
            using (SqlConnection conn = new SqlConnection(DBHelpers.Connection))
            {
                try
                {
                    conn.Open();
                    if (isbn != null)
                    {
                        string sql1 = "insert into BookStock(PlanBookID) select PlanBookID from PlanBook where ISBN=@ISBN and Examine='true'";
                        scm = new SqlCommand(sql1, conn);
                        scm.Parameters.AddWithValue("@ISBN", isbn);
                        i = scm.ExecuteNonQuery();
                    }
                    else
                    {
                        string sql1 = "insert into BookStock(PlanBookID) select PlanBookID from PlanBook where Examine='true'";
                        scm = new SqlCommand(sql1, conn);
                        scm.ExecuteNonQuery();
                    }
                }
                catch (Exception)
                {
                    
                    //throw;
                }
            }
            return i;

        }

        public void deleteStockBookID(string isbn)
        {
            SqlCommand scm;
            using (SqlConnection conn = new SqlConnection(DBHelpers.Connection))
            {
                try
                {
                    conn.Open();
                    scm = new SqlCommand();
                    scm.Connection = conn;
                    if (isbn == null)
                    {
                        string sql = "truncate table BookStock";
                        scm.CommandText = sql.ToString();
                        scm.ExecuteNonQuery();
                    }
                    else
                    {
                        string sql2 = "delete from BookStock where PlanBookID= (select PlanBook.PlanBookID from PlanBook where ISBN=@ISBN)";
                        scm.Parameters.AddWithValue("@ISBN", isbn);
                        scm.CommandText = sql2;
                        scm.ExecuteNonQuery();

                    }
                }
                catch (Exception)
                {
                    
                    //throw;
                }
                
            }
        }
    }
}
