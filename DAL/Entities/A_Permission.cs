using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class A_Permission
    {
        public int A_Permission_ID { get; set; }
        public int Album_ID { get; set; }
        public int User_ID { get; set; }
        public String A_Permission_Typpe { get; set; }

        public Album Album { get; set; }

        public User User { get; set; }
    }
}
