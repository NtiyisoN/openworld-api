using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using norwold.model;
using DataModel.libCampaign;
using DataModel.libDB;


namespace DataModel.libCampaign.maps
{
    public class campHexMap : ClassMap<campHex>
    {
        public campHexMap()
        {
            Table("camp_hexes");
            LazyLoad();
            Id(x => x.id).GeneratedBy.Identity().Column("id");
            Map(x => x.Name).Column("Name").Length(nwdbConst.LEN_SHORT);
            Map(x => x.LongName).Column("LongName").Length(nwdbConst.LEN_LONG);
            Map(x => x.Description).Column("description").CustomType("StringClob").CustomSqlType("nvarchar(max)");
            Map(x => x.X).Column("X");
            Map(x => x.Y).Column("Y");

            HasMany(x => x.Milestones).Cascade.All().KeyColumn("campHex_id");

            References(x => x.TerrainType).Column("sysTerrainType_id");
            References(x => x.Location).Column("campTreeLocation_id");

        }
    }
}
