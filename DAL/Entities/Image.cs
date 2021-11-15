using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Image
    {
        public int Image_ID { get; set; }
        public int Album_ID { get; set; }
        public String? Image_Name { get; set; }
        public DateOnly Image_Capture_Date { get; set; } //review data type
        public String? Image_Captured_By { get; set; } //entity for photographers?
        public String? Image_Tags { get; set; } //reffer bag to users? FK User_ID
        public String? Geolocation { get; set; } //review data type !!
        public String? Other_Metadata { get; set; } // lets be more specific. This could be a mojor security and pprivacy breach


    }
}
