using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using norwold.model;
using DataModel.libDB;


namespace DataModel.libData.maps
{


    public class sysBaseCombatStatMap : ClassMap<sysBaseCombatStat>
    {

        public sysBaseCombatStatMap()
        {
            Table("sys_combatstat");
            LazyLoad();
            Id(x => x.id).GeneratedBy.Identity().Column("id");
            Map(x => x.Name).Column("Name").Length(nwdbConst.LEN_SHORT).Not.Nullable();
            Map(x => x.LongName).Column("LongName").Length(nwdbConst.LEN_LONG).Not.Nullable();
            Map(x => x.Description).Column("LongName");
            Map(x => x.min).Column("Min");
            Map(x => x.max).Column("Max");
            Map(x => x.defvalue).Column("default");

            //Foreigns
            References(x => x.StatisticGroup).Column("sysTreeCombatStat_id");
            References(x => x.RuleSet).Column("sysBaseRuleSet_id");
        }
    }
}
