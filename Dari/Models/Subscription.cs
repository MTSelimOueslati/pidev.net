using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Stripe.Infrastructure;

namespace Dari.Models
{

    public class Subscription
    {
        public int idsubscription { get; set; }
        public float offer { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public String subtype { get; set; }
        public User user { get; set; }

    }
}