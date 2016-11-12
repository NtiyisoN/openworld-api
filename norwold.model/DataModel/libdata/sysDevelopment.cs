using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataModel.libCampaign;
using DataModel.libDB;


namespace DataModel.libData
{
    public class sysDevelopment : nwdbDataType         
    {
        public virtual string Description { get; set; }
        public virtual sysTreeDevelopment DevelopmentGroup { get; set; }
        public virtual IList<campXPSpent> XPSpent { get; set; }
        public virtual IList<campMilestone> Milestones { get; set; }

        
        public sysDevelopment() : base() {
            XPSpent = new List<campXPSpent>();
            Milestones = new List<campMilestone>();

        }
        public sysDevelopment(string n, string nl) : this() {
            this.Name = n.Substring(0, Math.Min(nwdbConst.LEN_SHORT , n.Length ));
            this.LongName = nl.Substring(0, Math.Min(nwdbConst.LEN_LONG , nl.Length ));
        }
        public sysDevelopment(string n, string nl,sysTreeDevelopment st) : this(n, nl) {
            this.DevelopmentGroup = st;
            st.Paths.Add(this);
        }

        
    }
}
