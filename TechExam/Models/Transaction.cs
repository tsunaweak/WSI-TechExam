using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace TechExam.Models
{
    public class Transaction
    {
        private Model model;
        public Transaction()
        {
            this.model = new Model();
        }


        public void Save(int total_amount, int cash_amount, int change_amount, int[] carts) {
            string sql = "EXEC dbo.nsp_Transactions @query = 2";
            SqlCommand cmd = new SqlCommand(sql, this.model.conn);
            int max_id = Int32.Parse(this.model.LoadString(cmd));
            this.model.conn.Open();
            SqlTransaction transaction = this.model.conn.BeginTransaction();
          
            try
            {
                foreach (int cart_id in carts)
                {
                    sql = $@"EXEC dbo.nsp_Transactions @id = " + max_id + ", @total_amount = " + total_amount + ", @cash_amount = " + cash_amount + ", @change_amount = " + change_amount + ", @cart_id = " + cart_id + ", @query = 1";
                    cmd = new SqlCommand(sql, this.model.conn, transaction);
                    cmd.ExecuteNonQuery();
                }
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
      
            }

            this.model.conn.Close();



        }
    }
}