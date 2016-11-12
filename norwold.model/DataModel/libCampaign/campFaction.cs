using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using norwold.model;
using DataModel.libDB;


namespace DataModel.libCampaign
{
    [Serializable()]
    public class campFaction : nwdbDataType
    {
        
        public campFaction()
            : base() {
            this.Milestones = new List<campMilestone>();
        }
        public campFaction(string n, string nl) : this() {
            this.Name = n.Substring(0, Math.Min(nwdbConst.LEN_SHORT , n.Length ));
            this.LongName = nl.Substring(0, Math.Min(nwdbConst.LEN_LONG , nl.Length ));

        }

        public virtual string Description { get; set; }
        public virtual IList<campMilestone> Milestones { get; set; }


        //public virtual hostChar NPCs { get; set; }
        //public virtual hostChar NPCs { get; set; }
    }

    
}
