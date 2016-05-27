using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.SqlClient;
using ManageBook.Modle;

namespace ManageBook.DAL
{
    public class DALGetBook
    {
        public void UpdateGetBook(GetBook gb) 
        {
            SqlTransaction sqltran;
            using (SqlConnection conn = new SqlConnection(DBHelpers.Connection)) 
            {
                conn.Open();
                string sql1 = "";
                string sql2 = "update BookStock set ArriveQuantity=ArriveQuantity-@GetBookNum2 where PlanBookID=(select PlanBookID from PlanBook where ISBN=@ISBN2) ";
                SqlCommand scm = new SqlCommand();
                scm.Connection = conn;
                sqltran = conn.BeginTransaction();
                scm.Transaction = sqltran;

                
                scm.Parameters.AddWithValue("@ISBN",gb.ISBN);
                scm.Parameters.AddWithValue("@GetBookNum",gb.GetBookNum);
                scm.Parameters.AddWithValue("@Signer",gb.Signer);
                scm.Parameters.AddWithValue("@SigerIdentity",gb.SignerIdentity);
                scm.Parameters.AddWithValue("@SigerPhone", gb.SignerPhone);
                if (gb.CollegeID == 0)
                {
                    sql1 = "insert into GetBook(PlanBookID,GetBookNum,Signer,SignerIdentity,SignerPhone) select 'PlanBookID'=(select PlanBookID from PlanBook where ISBN=@ISBN),@GetBookNum,@Signer,@SigerIdentity,@SigerPhone";
                }
                else
                {
                    sql1 = "insert into GetBook(PlanBookID,GetBookNum,Signer,SignerIdentity,SignerPhone,CollegeID,StudentClassID,SchoolTermID) select 'PlanBookID'=(select PlanBookID from PlanBook where ISBN=@ISBN),@GetBookNum,@Signer,@SigerIdentity,@SigerPhone,@CollegeID,@StudentClassID,@SchoolTermID";
                    scm.Parameters.AddWithValue("@CollegeID", gb.CollegeID);
                    scm.Parameters.AddWithValue("@StudentClassID", gb.StudentClassID);
                    scm.Parameters.AddWithValue("@SchoolTermID", gb.SchoolTermID);
                }
                scm.CommandText = sql1;
                scm.ExecuteNonQuery();

                scm.CommandText = sql2;
                scm.Parameters.AddWithValue("@GetBookNum2",gb.GetBookNum);
                scm.Parameters.AddWithValue("@ISBN2", gb.ISBN);
                scm.ExecuteNonQuery();

                sqltran.Commit();
            }
        }
    }
}
