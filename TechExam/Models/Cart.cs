using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TechExam.Types;
using System.Data;
namespace TechExam.Models
{
    public class Cart
    {
       


        private Model model;
        public Cart()
        {
            this.model = new Model();
        }

        public DataTable FindAll()
        {
            string sql = "EXEC dbo.nsp_Cart @query = 0";
            SqlCommand cmd = new SqlCommand(sql, this.model.conn);
            return this.model.LoadData(cmd);
        }

        public string getTotalAmount() {
            string sql = "EXEC dbo.nsp_Cart @query = 3";
            SqlCommand cmd = new SqlCommand(sql, this.model.conn);
            return this.model.LoadString(cmd);
        }


        public void Save(int qty, int product_id) {
            string sql = $@"EXEC dbo.nsp_Cart @qty = "+qty+ ", @product_id = "+product_id+ ", @query = 1";

       
            SqlCommand cmd = new SqlCommand(sql, this.model.conn);
            this.model.conn.Open();
            cmd.ExecuteNonQuery();
            this.model.conn.Close();
        }

        public void Remove(int cart_id) {
            string sql = $@"EXEC dbo.nsp_Cart @id = "+cart_id+",  @query = 2";
            SqlCommand cmd = new SqlCommand(sql, this.model.conn);
            this.model.conn.Open();
            cmd.ExecuteNonQuery();
            this.model.conn.Close();
        }

    }
}