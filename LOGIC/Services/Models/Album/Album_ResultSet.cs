using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGIC.Services.Models.Album
{
    public class Album_ResultSet
    {
        public int Album_ID { get; set; }
        public String Album_Name { get; set; }
        public String Album_Description { get; set; }
        public ICollection<Image> Images { get; set; }
    }
}
