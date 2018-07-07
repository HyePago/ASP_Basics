using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP_MVC_기초.Models
{
    public class CInstance
    {
        public static CUserManager theUserManager;
        public static int bInit = 0;
        
        public static void Initailize()
        {
            if(bInit == 0)
            {
                theUserManager = new CUserManager();
            }
            bInit = 1;
        }
    }
}