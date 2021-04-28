using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dari.Models
{
    public class Contract
    {
        public int id { get; set; }
        public ContractType type { get; set; }

        public String buyer { get; set; }
        public String seller { get; set; }
        public float sum { get; set; }
        public String address { get; set; }
        public DateTime date { get; set; }
        public User user { get; set; }
    }
}