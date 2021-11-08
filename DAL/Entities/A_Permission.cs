using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    internal class A_Permission
    {
        public int A_Permission_ID { get; set; }
        public int Image_ID { get; set; }
        public int User_ID { get; set; }
        public string A_Permission_Typpe { get; set; }
    }
}
