using System;
using System.Text;
using System.Collections.Generic;
using NHibernate;
using DataModel.libHosting;
using norwold.model;

namespace DataModel.libCampaign
{

    [Serializable()]
    public class campCharCampaign  {
        
        public campCharCampaign() : base() {
            
        }
 
        public campCharCampaign(campCampaign camp, hostChar ch, bool bApproved):this () {
            this.Campaign = camp;
            this.Character = ch;
            this.Approved = bApproved;
        }

        public virtual int id { get; protected set; }       
        public virtual campCampaign Campaign { get; set;}
        public virtual hostChar Character { get; set;}
        public virtual bool Approved { get; set; }
        public virtual string RejectComment { get; set; }
    }
}
