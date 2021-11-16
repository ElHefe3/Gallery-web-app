﻿namespace WEB_API.Models.Image
{
    public class Image_Pass_Object
    {

        public int album_id { get; set; }
        public String image_name { get; set; }
        public DateOnly image_capture_date { get; set; } //review data type
        public String image_captured_by { get; set; } //entity for photographers?
        public String image_tags { get; set; } //refer bag to users? FK User_ID
        public String geolocation { get; set; } //review data type !!
        public String other_metadata { get; set; } // to be amended
    }
}
