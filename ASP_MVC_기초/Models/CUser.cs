using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP_MVC_기초.Models
{
    public class CUser
    {
        public int theUniuqeID { get; set; }
        public string theID { get; set; }
        public string thePW { get; set; }
        
        public string theName { get; set; }
        public string theEMail { get; set; }
        public bool bSubscription { get; set; }

        public DateTime theDate { get; set; }
    }
}