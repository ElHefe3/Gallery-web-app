using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class A_Permission
    {
        public Int64 A_Permission_ID { get; set; }
        public Int64 Album_ID { get; set; }
        public Int64 User_ID { get; set; }
        public String? A_Permission_Type { get; set; }

        public Album? Album { get; set; } //BN comment - why?

        public User? User { get; set; } //BN comment - why?
    }
}
