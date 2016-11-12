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
using DataModel.libDB;
using DataModel.libData;

namespace DataModel.libData.Maps
{
    public class sysTreeMap : ClassMap<nwdbTree>
    {
        public sysTreeMap()
        {
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.Name).UniqueKey("Categories_UK_Name");
            Map(x => x.Value);
            this.MapTree("sysCategories"); // all magic goes here
            DiscriminateSubClassesOnColumn("ClassType").Not.Nullable().UniqueKey("Categories_UK_Name");
        }
    }

    public class sysTreeRuleSetMap : SubclassMap<sysTreeRuleSet>
    {
        public sysTreeRuleSetMap()
        {
            DiscriminatorValue(@"RuleSetTypes");
            HasMany(x => x.RuleSets).Cascade.All();
        }
    }
  

    public class sysTreeItemTypeMap : SubclassMap<sysTreeItemType>
    {
        public sysTreeItemTypeMap()
        {
            DiscriminatorValue(@"ItemTypes");
            HasMany(x => x.Items).Cascade.All();
        }
    }
    public class sysTreeStatisticMap : SubclassMap<sysTreeStatistic>
    {
        public sysTreeStatisticMap()
        {
            DiscriminatorValue(@"Statistic");
            HasMany(x => x.Statistics).Cascade.All();
            Map(x => x.isCalculated);
        }
    }

    public class sysTreeDevelopmentMap : SubclassMap<sysTreeDevelopment>
    {
           public sysTreeDevelopmentMap()
        {
            DiscriminatorValue(@"Development");
            HasMany(x => x.Paths).Cascade.All();
        }
    }

    public class sysTreeCombatStatMap : SubclassMap<sysTreeCombatStat>
    {
        public sysTreeCombatStatMap()
        {
            DiscriminatorValue(@"Combat Stats");
            HasMany(x => x.CombatStats).Cascade.All();
        }
    }

 }
    
