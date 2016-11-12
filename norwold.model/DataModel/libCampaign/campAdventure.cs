using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataModel.libHosting;
using DataModel.libDB;


namespace DataModel.libCampaign
{
    [Serializable()]
    public class campAdventure : nwdbDataType
    {

        
        public campAdventure()
            : base()
        {
            this.Rewards = new List<campXPGained>();
            this.Milestones = new List<campMilestone>();
            if (this.Date == DateTime.MinValue) { this.Date = nwdbConst.minSQLDate; }
        }

        public campAdventure(string n, string nl)
            : this()
        {
            this.Name = n.Substring(0, Math.Min(nwdbConst.LEN_SHORT , n.Length ));
            this.LongName = nl.Substring(0, Math.Min(nwdbConst.LEN_LONG , nl.Length ));
        }

        public campAdventure(string n, string nl,string desc,campCampaign camp, DateTime dt)
            : this(n,nl)
        {
            this.Description = desc;
            this.Campaign = camp;
        }



        public virtual string Description { get; set; }
        public virtual DateTime Date { get; set; }
        public virtual campCampaign Campaign { get; set; }
        public virtual IList<campXPGained> Rewards { get; set; }
        public virtual IList<campMilestone> Milestones { get; set; }
        public virtual IList<hostChar> GetPlayers()
        {
            IList<hostChar> result = new List<hostChar>();
            foreach (campXPGained xp in Rewards)
            {
                if (xp.Character != null) { 
                    result.Add(xp.Character);
                }
            }
            return result;
        }

    }
}
