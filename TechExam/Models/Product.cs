using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TechExam.Models;

namespace TechExam.Models
{
   

    public class Product  
    {
        private Model model;
        public Product() {
            this.model = new Model();
        }

        public DataTable Find(int Id) {
            
        
            string sql = "EXEC dbo.nsp_Product @id = " + Id + ", @query = 1";
            SqlCommand cmd = new SqlCommand(sql, this.model.conn);
            return this.model.LoadData(cmd);
        }

        
        

    }
}