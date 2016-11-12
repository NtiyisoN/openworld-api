using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using norwold.model;
using DataModel.libDB;


namespace DataModel.libData.maps
{


    public class sysBaseDamageTypeMap : ClassMap<sysBaseDamageType>
    {

        public sysBaseDamageTypeMap()
        {
            Table("sys_dmgtypes");
            LazyLoad();
            Id(x => x.id).GeneratedBy.Identity().Column("id");
            Map(x => x.Name).Column("Name").Length(nwdbConst.LEN_SHORT).UniqueKey("sysDamageType_UK_ShortName").Not.Nullable();
            Map(x => x.LongName).Column("LongName").Length(nwdbConst.LEN_LONG).Not.Nullable();
            
            //References
            References(x => x.RuleSet).Column("sysBaseRuleSet_id");
        }
    }
}
