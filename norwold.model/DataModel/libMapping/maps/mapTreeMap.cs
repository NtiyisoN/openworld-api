using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brandy.Grapes.FluentNHibernate;
using Brandy.Grapes;
using FluentNHibernate;
using FluentNHibernate.Mapping;
using FluentNHibernate.MappingModel;
using norwold.model;
using DataModel.libMapping;
using DataModel.libCampaign;

namespace DataModel.libMapping.maps
{
    public class mapTreeMap : ClassMap<mapTree>
    {
        public mapTreeMap()
        {
            Table("map_tree");
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.Name).UniqueKey("mapCategories_UK_Name");
            Map(x => x.Value);
            this.MapTree("mapCategories"); // all magic goes here
            DiscriminateSubClassesOnColumn("ClassType").Not.Nullable().UniqueKey("mapCategories_UK_Name");
        }
    }

  

    public class mapTreeTerrainMap : SubclassMap<mapTreeTerrain>
    {
        public mapTreeTerrainMap()
        {
            DiscriminatorValue(@"mapTreeTerrain");
            HasMany(x => x.TerrainTypes).Cascade.All();
        }
    }

    public class mapTreePOIMap : SubclassMap<mapTreePOI>
    {
        public mapTreePOIMap()
        {
            DiscriminatorValue(@"mapTreePOI");
            HasMany(x => x.POITypes).Cascade.All();
        }
    }

 
  

}
    
