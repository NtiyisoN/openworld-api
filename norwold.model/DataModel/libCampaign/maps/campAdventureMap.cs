using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using norwold.model;
using DataModel.libDB;
 

namespace DataModel.libCampaign.maps
{
    public class campAdventureMap : ClassMap<campAdventure>
    {
        public campAdventureMap()
        {
            Table("camp_adventure");
            LazyLoad();
            Id(x => x.id).GeneratedBy.Identity().Column("id");
            Map(x => x.Name).Column("Name").Length(nwdbConst.LEN_SHORT);
            Map(x => x.LongName).Column("LongName").Length(nwdbConst.LEN_LONG);
            Map(x => x.Date).Column("AdventureDate");
            Map(x => x.Description).Column("description").CustomType("StringClob").CustomSqlType("nvarchar(max)");
            
            References(x => x.Campaign).Column("campCampaign_id");
            HasMany(x => x.Rewards).Cascade.All();
            HasMany(x => x.Milestones).Cascade.All();
        }
    }
}
