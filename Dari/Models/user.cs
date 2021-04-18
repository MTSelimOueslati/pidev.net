using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dari.Models
{
    public class User
    {
        public long id { get; set; }
        public String username { get; set; }
        public String address { get; set; }
        public int phone_number { get; set; }
        public String email { get; set; }
        public String Password { get; set; }
        public Boolean verified { get; set; }
        public Boolean subscribed { get; set; }
        public String idStripe { get; set; }
        public String role { get; set; }


    }
}