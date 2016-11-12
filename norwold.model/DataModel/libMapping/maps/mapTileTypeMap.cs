using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using DataModel.libDB;


namespace DataModel.libMapping.maps
{


    public class mapTileTypeMap : ClassMap<mapTileType>
    {

        public mapTileTypeMap()
        {
            Table("map_tiletype");
            LazyLoad();
            Id(x => x.id).GeneratedBy.Identity().Column("id");
            Map(x => x.Name).Column("Name").Length(nwdbConst.LEN_SHORT).Not.Nullable();
            Map(x => x.LongName).Column("LongName").Length(nwdbConst.LEN_LONG).UniqueKey("mapTileType_UK_LongName").Not.Nullable();
            Map(x => x.isHex);
            Map(x => x.is2D);
            Map(x => x.isProgressable);
            Map(x => x.isPublic);
            Map(x => x.Description).CustomType("StringClob").CustomSqlType("nvarchar(max)");
            Map(x => x.AuthorName);
   
        }
    }
}
