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

namespace DataModel.libCampaign.maps
{

    
    public class nwTreeMap : ClassMap<campTree>
    {
        public nwTreeMap()
        {
            Table("camp_tree");
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.Name).UniqueKey("campCategories_UK_Name");
            Map(x => x.Value);
            this.MapTree("campaignCategories"); // all magic goes here
            DiscriminateSubClassesOnColumn("ClassType").Not.Nullable().UniqueKey("campCategories_UK_Name");
        }
    }
   
  

    public class campTreeMilestoneTreeMap : SubclassMap<campTreeMileStone>
    {
        public campTreeMilestoneTreeMap()
        {
            DiscriminatorValue(@"Milestones");
            References(x => x.MilestoneType).Column("sysMilestoneType_id");
            HasMany(x => x.Milestones).Cascade.All();
 

        }
    }

    public class campTreeFactionMap : SubclassMap<campTreeFaction>
    {
        public campTreeFactionMap()
        {
            DiscriminatorValue(@"Factions");
            //References(x => x.DevType);
            HasMany(x => x.Factions).Cascade.All();
        }
    }

    public class campTreeLocationMap : SubclassMap<campTreeLocation>
    {
        public campTreeLocationMap()
        {
            DiscriminatorValue(@"Locations");
            HasMany(x => x.Hexes).Cascade.All();
        }
    }

  

}
    
