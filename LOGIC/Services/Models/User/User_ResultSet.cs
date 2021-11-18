using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGIC.Services.Models.User
{
    public class User_ResultSet
    {

        public Int64 user_id { get; set; }
        public String user_name { get; set; }
        public String user_surname { get; set; }
        public String user_email { get; set; }
        public String user_nickname { get; set; }
        public String user_passwordhash { get; set; } //review data type

      //  public ICollection<I_Permission> i_permissions { get; set; }

      //  public ICollection<A_Permission> a_permissions { get; set; }
    }
}
