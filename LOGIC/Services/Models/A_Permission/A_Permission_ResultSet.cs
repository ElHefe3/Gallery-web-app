using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace LOGIC.Services.Models.A_Permission
{
    public class A_Permission_ResultSet
    {
        public Int64 a_permission_id { get; set; }
        public Int64 album_id { get; set; }
        public Int64 user_id { get; set; }
        public String a_permission_type { get; set; }

       // public Album Album { get; set; } //BN comment - why?

     //   public User User { get; set; } //BN comment - why?
    }
}
