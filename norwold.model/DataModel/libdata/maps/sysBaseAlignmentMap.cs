using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using norwold.model;
using DataModel.libDB;


namespace DataModel.libData.maps
{


    public class sysBaseAlignmentMap : ClassMap<sysBaseAlignment>
    {

        public sysBaseAlignmentMap()
        {
            Table("sys_alignment");
            LazyLoad();
            Id(x => x.id).GeneratedBy.Identity().Column("id");
            Map(x => x.Name).Column("Name").Length(nwdbConst.LEN_SHORT).UniqueKey("sysAlignment_UK_ShortName").Not.Nullable();
            Map(x => x.LongName).Column("LongName").Length(nwdbConst.LEN_LONG).Not.Nullable();

            HasMany(x => x.Characters).Cascade.All().KeyColumn("sysAlignment_id");
            References(x => x.RuleSet).Column("sysBaseRuleSet_id");
        }
    }
}
