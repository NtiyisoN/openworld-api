using System;
using System.Collections.Generic;
using System.Text;
using FluentNHibernate.Mapping;
using norwold.model;
using DataModel.libCampaign;
using DataModel.libDB;


namespace DataModel.libCampaign.maps
{


    public class campMilestoneMap : ClassMap<campMilestone>
    {

        public campMilestoneMap()
        {
            Table("camp_milestones");
            Id(x => x.id).GeneratedBy.Identity().Column("id");
            Map(x => x.Occured).Column("Occured");
            Map(x => x.Name).Column("Name").Length(nwdbConst.LEN_SHORT);
            Map(x => x.LongName).Column("LongName").Length(nwdbConst.LEN_LONG);
            //mandatory
            References(x => x.SourceCharacter).Column("Sourcechar_id");
            References(x => x.Adventure).Column("campAdventure_id");
            References(x => x.Type).Column("campTreeMilestone_id");
            //optionals
            References(x => x.TargetFaction).Column("campFaction_id");
            References(x => x.TargetCharacter).Column("Targetchar_id");
            References(x => x.TargetItem).Column("nwItem_id");
            References(x => x.TargetHex).Column("campHex_id");
            References(x => x.TargetDevPath).Column("sysDevelopment_id");
            References(x => x.TargetLanguage).Column("sysLanguage_id");


          }

           }
}
