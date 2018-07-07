using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.Linq;

namespace ASP_MVC_기초.Models
{
    public class CUserManager
    {
        // private List<CUser> theUsers;
        LUserDataContext theUserContext;

        public CUserManager()
        {
            // theUsers = new List<CUser>();
            theUserContext = new LUserDataContext();
        }

        public int AddUser(ref CUser aUser)
        {
            /* CUser tmpUser = new CUser();
            tmpUser.theUniuqeID = 0;
            tmpUser.theDate = DateTime.Now; */

            TUser3209 tmpUser = new TUser3209();

            tmpUser.theID = aUser.theID;
            tmpUser.thePW = aUser.thePW;
            tmpUser.theName = aUser.theName;
            tmpUser.theEMail = aUser.theEMail;
            tmpUser.bSubscription = aUser.bSubscription ? 1 : 0;
            tmpUser.theDate = DateTime.Now;

            theUserContext.TUser3209.InsertOnSubmit(tmpUser);
            theUserContext.SubmitChanges();

            aUser.theDate = tmpUser.theDate;

            return 1;
        }

        public List<CUser> GetUsers()
        {
            // return theUsers;

            IQueryable<TUser3209> tmpR = theUserContext.TUser3209.OrderByDescending(x => x.theID);

            List<TUser3209> tmpL = tmpR.ToList<TUser3209>();
            List<CUser> resUsers = new List<CUser>();
            
            foreach(TUser3209 iter in tmpL)
            {
                CUser tmpUser = new CUser();

                tmpUser.theUniuqeID = iter.theUniqueID;
                tmpUser.theID = iter.theID;
                tmpUser.thePW = iter.thePW;
                tmpUser.theName = iter.theName;
                tmpUser.theEMail = iter.theEMail;
                tmpUser.bSubscription = iter.bSubscription == 1 ? true : false;
                tmpUser.theDate = iter.theDate;

                resUsers.Add(tmpUser);
            }

            return resUsers;
        }

        public int CheckUser(string ID, string PW)
        {
            return 0;
        }
    }
}