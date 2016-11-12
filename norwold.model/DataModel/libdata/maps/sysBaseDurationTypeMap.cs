using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using norwold.model;
using DataModel.libDB;


namespace DataModel.libData.maps
{


    public class sysBaseDurationTypeMap : ClassMap<sysBaseDurationType>
    {

        public sysBaseDurationTypeMap()
        {
            Table("sys_duration");
            LazyLoad();
            Id(x => x.id).GeneratedBy.Identity().Column("id");
            Map(x => x.Name).Column("Name").Length(nwdbConst.LEN_SHORT).UniqueKey("sysAlignment_UK_ShortName").Not.Nullable();
            Map(x => x.LongName).Column("LongName").Length(nwdbConst.LEN_LONG).Not.Nullable();
            Map(x => x.Seconds);

            //Foreigns
            References(x => x.RuleSet).Column("sysBaseRuleSet_id");
        }
    }
}
