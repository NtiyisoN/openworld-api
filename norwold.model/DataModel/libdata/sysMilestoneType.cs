using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataModel.libCampaign;
using DataModel.libDB;


namespace DataModel.libData
{
    public class sysMilestoneType : nwdbDataType
    {
        public sysMilestoneType() : base() {
            MileStoneTree = new List<campTreeMileStone>();
        }
        public sysMilestoneType(string n, string nl) : this() {
            this.Name = n.Substring(0, Math.Min(nwdbConst.LEN_SHORT , n.Length ));
            this.LongName = nl.Substring(0, Math.Min(nwdbConst.LEN_LONG , nl.Length ));
        }

        public virtual IList<campTreeMileStone> MileStoneTree { get; set; }
        public virtual bool isCharMandatory { get; set; }
        public virtual bool isFactionMandatory { get; set; }
        public virtual bool isHexMandatory { get; set; }
        public virtual bool isItemMandatory { get; set; }
        public virtual bool isDevPathMandatory { get; set; }
        public virtual bool isLanguageMandatory { get; set; }
        public virtual bool isPOIMandatory { get; set; }

        public static void SeedListData(IList<sysMilestoneType> miletypes) {
            
            sysMilestoneType mPeople, mPlace, mSkill, mFaction, mItem;

            mPeople = new sysMilestoneType("People", "People");
            mPeople.isCharMandatory = true;

            mPlace = new sysMilestoneType("Place", "Place");
            mPlace.isHexMandatory = true;
            mPlace.isPOIMandatory = true;

            mSkill = new sysMilestoneType("Skill", "Skill/Knowledge");
            mSkill.isDevPathMandatory = true;

            mFaction = new sysMilestoneType("Faction", "Faction");
            mFaction.isFactionMandatory = true;
            
            mItem = new sysMilestoneType("Equipment", "Equipment");
            mItem.isItemMandatory = true;

            miletypes.Add(mPeople);
            miletypes.Add(mPlace);
            miletypes.Add(mSkill);
            miletypes.Add(mFaction);
            miletypes.Add(mItem);

        }
    }

    
}
