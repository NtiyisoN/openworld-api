using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using norwold.model;
using DataModel.libDB;


namespace DataModel.libMapping.maps
{


    public class mapTerrainTypeMap : ClassMap<mapTerrainType>
    {

        public mapTerrainTypeMap()
        {
            Table("map_terraintype");
            LazyLoad();
            Id(x => x.id).GeneratedBy.Identity().Column("id");
            Map(x => x.Name).Column("Name").Length(nwdbConst.LEN_SHORT).Not.Nullable();
            Map(x => x.LongName).Column("LongName").Length(nwdbConst.LEN_LONG).UniqueKey("sysBaseTerrain_UK_LongName").Not.Nullable();
            Map(x => x.Elevation).Column("Elevation");
            Map(x => x.HeightTerrain).Column("HeightTerrain");
            Map(x => x.StepCost).Column("StepCost");
            Map(x => x.ResourceName).Column("ResourceName");
            Map(x => x.ImportName).Column("ImportName");
            Map(x => x.bgColor).CustomType<UserTypeColor>().Column("bgColor");
            Map(x => x.Value).Column("Value");
            Map(x => x.isTransparent).Column("isTransparent");
            Map(x => x.Tile).CustomType<UserTypeBitMap>().Column("Image");

            References(x => x.TerrainType).Column("mapTreeTerrain_id");

            HasMany(x => x.Hexes).Cascade.All();

        }
    }
}
