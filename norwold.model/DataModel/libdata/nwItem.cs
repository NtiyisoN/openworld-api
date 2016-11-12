using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataModel.libHosting;
using DataModel.libCampaign;
using DataModel.libDB;



namespace DataModel.libData
{
        [Serializable()]
    public class nwItem : nwdbDataType
    {

        public nwItem() : base() { }
 
        public nwItem(string n,string nl):base (n,nl) {
            //class specifics here;
            this.Milestones = new List<campMilestone>();

        }
        public virtual string Description { get; set; }
        public virtual hostChar Owner { get; set; }
        public virtual int Bonus { get; set; }
        public virtual sysTreeItemType ItemType { get; set; }
        public virtual sysDamageRoll DamageSmall { get; set; }
        public virtual sysDamageRoll DamageLarge { get; set; }

        public virtual IList<campMilestone> Milestones { get; set;}
    }
}
