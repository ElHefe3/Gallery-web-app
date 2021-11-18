namespace WEB_API.Models.User
{
    public class User_Pass_Object
    {
       
        public String user_name { get; set; }
        public String user_surname { get; set; }
        public String user_email { get; set; }
        public String user_nickname { get; set; }
        public String user_passwordhash { get; set; } //review data type

    }
}
