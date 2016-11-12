using System;
using System.Collections.Generic;
using System.Text;
using FluentNHibernate.Mapping;
using norwold.model;
using DataModel.libDB;


namespace DataModel.libData.maps
{


    public class sysBaseStatisticMap : ClassMap<sysBaseStatistic>
    {

        public sysBaseStatisticMap()
        {
            Table("sys_stats");
            LazyLoad();
            Id(x => x.id).GeneratedBy.Identity().Column("id");
            Map(x => x.Name).Column("Name").Length(nwdbConst.LEN_SHORT).UniqueKey("sysAttribute_UK_ShortName").Not.Nullable();
            Map(x => x.LongName).Column("LongName").Length(nwdbConst.LEN_LONG).Not.Nullable();
            Map(x => x.min).Column("min").Default("1");
            Map(x => x.max).Column("max").Default("25");
            Map(x => x.defvalue).Column("defvalue").Default("10");
            Map(x => x.Description).Column("description").CustomType("StringClob").CustomSqlType("nvarchar(max)");
 
            //foreigns
            References(x => x.StatisticGroup).Column("sysTreeStatistic_id");
            References(x => x.RuleSet ).Column("sysBaseRuleSet_id");
        }
    }
}
