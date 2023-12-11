using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace TechExam.Models
{
    public class Model
    {
        public SqlConnection conn;

        public Model() {
            conn = new SqlConnection() {
                ConnectionString = "Data Source=DESKTOP-J8MRI2F;Database=TechExam;User Id=sa;Password=P@ssw0rd"
            };
        }

        public DataTable LoadData(SqlCommand cmd) {
            conn.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            conn.Close();
            da.Dispose();
            return dt;
        }
        public string LoadString(SqlCommand cmd) {
       
            conn.Open();
            string result = string.Empty;
            result = cmd.ExecuteScalar().ToString();
            conn.Close();
            return result;
        }
    }
}