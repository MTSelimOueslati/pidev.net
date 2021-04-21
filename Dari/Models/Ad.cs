using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dari.Models;



namespace Dari.Models
{
    public class Ad
    {
        public int idAd { get; set; }
        public String ad { get; set; }
        public AdType adType { get; set; }
        public String description { get; set; }
        public float price { get; set; }
        public String location { get; set; }
        public float Area { get; set; }
        public String area { get; set; }
        public int nbrooms { get; set; }
        public int nbbath { get; set; }
        public int nbgarage { get; set; }
        public Boolean garden { get; set; }
        public Boolean elevator { get; set; }
        public Boolean pool { get; set; }
        public Boolean furnished { get; set; }
        public DateTime datecreated { get; set; }
        public State state { get; set; }

    }
}