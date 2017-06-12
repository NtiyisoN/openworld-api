using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using norwold.model;
using DataModel.libCampaign;
using DataModel.libDB;



namespace DataModel.libHosting
{
    [Serializable()]
    public class hostUser : nwdbDataType
    {

        public hostUser()
        {
            //Characters = new List<hostChar>();
            ///GMCampaigns = new List<campCampaign>();
            //Events = new List<hostUserEvent>();
            if (this.fbTokenExpires == DateTime.MinValue) { this.fbTokenExpires = nwdbConst.minSQLDate; }
        }

        public hostUser(string n, string nl)
            : this()
        {
            this.Name = n.Substring(0, Math.Min(nwdbConst.LEN_SHORT , n.Length ));
            this.LongName = nl.Substring(0, Math.Min(nwdbConst.LEN_LONG , nl.Length ));
        }
        
        public hostUser(string n, string nl, string email, string pw)
            : this(n,nl)
        {
            this.Email = email;
            this.Password = pw;

        }

        public hostUser(string n, string nl, hostFacebook fbRecord)
            : this(n, nl)
        {
            this.linkFaceBook(fbRecord);
        }
        /**
        public virtual bool CreateCampaign(string n, string nl,string email, string description)
        {
            try
            {
                campCampaign hc = new campCampaign(n,nl ,email,this,DateTime.Now, nwdbConst.minSQLDate,description);
                this.GMCampaigns.Add(hc);
                return true;
            }
            catch (Exception e)
            {
                string t = e.Message;
                return false;
            }


        }
        **/

        

        public virtual void linkFaceBook(hostFacebook fbRecord) {
            this.fbID =fbRecord.ID;
            this.fbGender = fbRecord.Gender;
            this.fbAccessToken = fbRecord.AccessToken;
            this.fbFirstName = fbRecord.FirstName;
            this.fbSurname = fbRecord.Surname;
            this.fbTokenExpires = fbRecord.Expires;
            if (this.Email == null || this.Email =="")
            {
                this.Email = fbRecord.Email;
            }
        }

        public virtual void RefreshToken(string newToken)
        {
            this.fbAccessToken = fbAccessToken;
        }

        public virtual void LogEvent(hostChar ch, campCampaign camp, string n, string nl, string desc)
        {
            hostUserEvent ev = new hostUserEvent(n, nl, this, ch, camp, desc);
            ev.DateOccured = DateTime.Now;
            //this.Events.Add(ev);
        }

        public virtual string Email { get; set; }
        public virtual string Password { get; set; }
        //public virtual IList<hostChar> Characters { get; set; }
        //public virtual IList<campCampaign> GMCampaigns { get; set; }
        //public virtual IList<hostUserEvent> Events { get; set; }
        
        public virtual string fbID { get; set; }
        public virtual string fbGender { get; set; }
        public virtual string fbAccessToken { get; set; }
        public virtual string fbFirstName { get; set; }
        public virtual string fbSurname { get; set; }
        public virtual DateTime fbTokenExpires { get; set; }

        public virtual hostUserType UserType { get; set; }
    
    }
}
