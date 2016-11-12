using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using DataModel.libDB;


namespace DataModel.libMapping.maps
{


    public class mapPOITypeMap : ClassMap<mapPOIType>
    {

        public mapPOITypeMap()
        {
            Table("map_poitype");
            LazyLoad();
            Id(x => x.id).GeneratedBy.Identity().Column("id");
            Map(x => x.Name).Column("Name").Length(nwdbConst.LEN_SHORT).Not.Nullable();
            Map(x => x.LongName).Column("LongName").Length(nwdbConst.LEN_LONG).UniqueKey("mapPOIType_UK_LongName").Not.Nullable();
            Map(x => x.StepCost).Column("StepCost");
            Map(x => x.ResourceName).Column("ResourceName");
            Map(x => x.ImportName).Column("ImportName");

            References(x => x.POIGroup).Column("mapTreePOI_id");
        }
    }
}
