using System;
using System.Text;
using System.Diagnostics;
using System.Collections.Generic;
using NHibernate;
using DataModel.libHosting;
using DataModel.libCampaign;
using DataModel.libData;
using DataModel.libDB;

namespace DataModel.libHosting
{
   
    [Serializable()]

    public class hostChar : nwdbDataType {
        
        public hostChar() : base() {
            this.Items = new List<nwItem>();
            this.CharStats = new List<hostCharStat>();
            this.XPGained = new List<campXPGained>();
            this.XPSpent = new List<campXPSpent>();
            this.Campaigns = new List<campCharCampaign>();
        }
 
        public hostChar(string n,string nl):this () {
            this.Name = n.Substring(0, Math.Min(nwdbConst.LEN_SHORT , n.Length ));
            this.LongName = nl.Substring(0, Math.Min(nwdbConst.LEN_LONG , nl.Length ));
        }

        public hostChar(string n, string nl, hostUser log)
            : this(n, nl)
        {
            //this.Logon = log;
        }
        
        public virtual bool isNPC { get; set; }
        public virtual int? id_table_domain { get; set; }
        public virtual string Description { get; set; }

        public virtual IList<nwItem> Items { get; set; }
        public virtual IList<hostCharStat> CharStats { get; set; }
        public virtual IList<campXPGained> XPGained { get; set; }
        public virtual IList<campXPSpent> XPSpent { get; set; }
        public virtual IList<campCharCampaign> Campaigns { get; set; }
        public virtual IList<campMilestone> SourceMilestones { get; set; }
        public virtual IList<campMilestone> TargetMilestones { get; set; }

        public virtual sysBaseAlignment Alignment { get; set; }
        //public virtual hostUser Logon { get; set; }

        public virtual void RefreshCharacterStats(ISession sess)
        {
            bool bContains;
            //create default stats
            
            IList<sysBaseStatistic> allstats = sess.CreateCriteria(typeof(sysBaseStatistic))
                    .List<sysBaseStatistic>();
            foreach (sysBaseStatistic s in allstats)
            {
                bContains = false;
                foreach (hostCharStat c in this.CharStats) {
                    if (c.stat == s) {
                        bContains = true;
                        break;
                    }
                }
                if (!bContains)
                {
                    hostCharStat sv = new hostCharStat(s, this, s.defvalue);
                    CharStats.Add(sv);
                }
                else
                {
                    Debug.Print("Character:" + this.LongName + " has a stat for:" + s.LongName);
                }
            }

        }

        protected override string ToLongString()
        {
            int l;
            string did;
            if (this.Description == null) { l = 0; } else { l = this.Description.Length; }
            if (this.id_table_domain == null) { did = "null"; } else { did = id_table_domain.ToString(); }
            return "hostChar ID " + this.id.ToString() + " Name:" + this.Name + " LongName:" + this.LongName +
                   " DescriptionLength:" + l.ToString() + "DomainID:"+ did;
        }


    }
}
