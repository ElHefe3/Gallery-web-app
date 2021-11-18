using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class User
    {
        public Int64 User_ID { get; set; }
        public String? User_Name { get; set;}
        public String? User_Surname { get; set; }
        public String? User_Email { get; set;}
        public String? User_Nickname { get; set; }
        public String? User_PasswordHash { get; set; } //review data type

        public ICollection<I_Permission>? I_Permissions { get; set; }

        public ICollection<A_Permission>? A_Permissions { get; set; }
        
    }
}
