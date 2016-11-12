using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using norwold.model;
using DataModel.libCampaign;
using DataModel.libDB;


namespace DataModel.libHosting
{
    public class hostUserEvent : nwdbDataType
    {

        public hostUserEvent() {
            if (this.DateOccured == DateTime.MinValue || this.DateOccured ==null ) { this.DateOccured = nwdbConst.minSQLDate; }; 
        }

        public hostUserEvent(string n, string nl)
            : this()
        {
            this.Name = n.Substring(0, Math.Min(nwdbConst.LEN_SHORT , n.Length ));
            this.LongName = nl.Substring(0, Math.Min(nwdbConst.LEN_LONG , nl.Length ));
        }
        
        public hostUserEvent(string n, string nl,hostUser usr, hostChar ch, campCampaign camp,string desc)
            : this(n,nl)
        {
            this.Character = ch;
            this.Campaign = camp;
            this.Description = desc;
            this.User = usr;
        }
        
       
        public virtual hostChar Character { get; set; }
        public virtual campCampaign Campaign { get; set; }
        public virtual hostUser User { get; set; }
        public virtual string Description { get; set; }
        public virtual bool Viewed { get; set; }
        public virtual bool Sent { get; set; }
        public virtual DateTime DateOccured { get; set; }

    }
}
