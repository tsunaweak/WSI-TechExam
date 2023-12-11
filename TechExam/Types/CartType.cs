using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TechExam.Types
{
    public class CartType
    {
        public int id { get; set; }
        public float amount { get; set; }

        public int qty { get; set; }
        public int product_id { get; set; }
    }
}