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
        public String password;
        public Boolean verified { get; set; }
        public Boolean subscribed { get; set; }
        public String id_strype { get; set; }
        public ISet<Role> roles { get; set; }

        public virtual string Password
        {
            get
            {
                return password;
            }
            set
            {
                this.password = value;
            }
        }
    }
}