using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGIC.Services.Models.Album
{
    public class Album_ResultSet
    {
        public Int64 album_id { get; set; }
        public String album_name { get; set; }
        public String album_description { get; set; }
       // public ICollection<Image> images { get; set; }
    }
}
