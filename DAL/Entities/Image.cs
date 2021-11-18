using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Image
    {
        public Int64 Image_ID { get; set; }
        public Int64 Album_ID { get; set; }
        public String? Image_Name { get; set; }
        public DateTime Image_Captured_Date { get; set; } //review data type
        public String? Image_Captured_By { get; set; } //entity for photographers?
        public String? Image_Tags { get; set; } //reffer bag to users? FK User_ID
        public String? Geolocation { get; set; } //review data type !!
        public String? Other_Metadata { get; set; } // lets be more specific. This could be a mojor security and pprivacy breach

        public ICollection<I_Permission>? I_Permissions { get; set; }

        public Album? Albums { get; set; } //BN added




    }
}
