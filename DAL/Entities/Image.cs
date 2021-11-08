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
        public string Image_Name { get; set; }
        public DateOnly Image_Capture_date { get; set; } //review data type
        public string Image_Captured_By { get; set; } //entity for photographers?
        public string Image_Tags { get; set; } //reffer bag to users? FK User_ID
        public string Geolocation { get; set; } //review data type !!
        public string Other_Metadata { get; set; } // lets be more specific. This could be a mojor security and pprivacy breach
    }
}
