using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class User
    {
        public int User_ID { get; set; }
        public string User_Name { get; set;}
        public string User_Surname { get; set; }
        public string User_Email { get; set;}
        public string User_Nickname { get; set; }
        public string Passwordd_Hash { get; set; } //review data type
        
    }
}
