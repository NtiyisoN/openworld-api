using System;
using System.Collections.Generic;
using System.Text;
using FluentNHibernate.Mapping;
using norwold.model;
using DataModel.libDB;


namespace DataModel.libCampaign.maps
{


    public class campFactionMap : ClassMap<campFaction>
    {

        public campFactionMap()
        {
            Table("camp_faction");
            Id(x => x.id).GeneratedBy.Identity().Column("id");
            Map(x => x.Name).Column("Name").Length(nwdbConst.LEN_SHORT);
            Map(x => x.LongName).Column("LongName").Length(nwdbConst.LEN_LONG);
            Map(x => x.Description).Column("description").CustomType("StringClob").CustomSqlType("nvarchar(max)");

            HasMany(x => x.Milestones).KeyColumn("campFaction_id");
        }

        
    }
}
