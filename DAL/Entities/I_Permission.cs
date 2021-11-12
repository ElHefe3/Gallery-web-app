using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class I_Permission
    {
        public int I_Permission_ID { get; set; }
        public int Image_ID { get; set; }
        public int User_ID { get; set; }
        public String I_Permission_Type { get; set; }

        public Image Image { get; set; } //BN Comment - why add this??

        public User User { get; set; } //BN Comment - why add this??
    }
}
