using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Album
    {
        public int Album_ID { get; set; }
        public String? Album_Name { get; set; }
        public String? Album_Description { get; set; }

        public ICollection<Image>? Images { get; set; }

        public ICollection<A_Permission>? A_Permissions { get; set; }
    }
}
