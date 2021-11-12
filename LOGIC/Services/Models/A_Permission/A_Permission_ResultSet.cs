using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGIC.Services.Models.A_Permission
{
    public class A_Permission_ResultSet
    {
        public int A_Permission_ID { get; set; }
        public int Album_ID { get; set; }
        public int User_ID { get; set; }
        public String A_Permission_Type { get; set; }

       // public Album Album { get; set; } //BN comment - why?

       // public User User { get; set; } //BN comment - why?
    }
}
