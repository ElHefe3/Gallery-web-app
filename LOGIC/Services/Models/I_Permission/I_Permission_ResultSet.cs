using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGIC.Services.Models.I_Permission
{
    public class I_Permission_ResultSet
    {
        public int i_permission_id { get; set; }
        public int image_id { get; set; }
        public int user_id { get; set; }
        public String i_permission_type { get; set; }

       // public Image Image { get; set; } //BN Comment - why add this??

     //   public User User { get; set; } //BN Comment - why add this??
    }
}
