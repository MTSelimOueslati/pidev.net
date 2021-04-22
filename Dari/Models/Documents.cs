using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dari.Models
{
    public class Documents
    {
        public int id { get; set; }
        public sbyte[] fichedepaie { get; set; }
        public sbyte[] piecedidentite { get; set; }
        public sbyte[] lettredengagement { get; set; }
        public sbyte[] cautionnement { get; set; }

    }
}