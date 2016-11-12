using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using norwold.model;
using DataModel.libDB;


namespace DataModel.libData.maps
{


    public class sysBaseRulesetMap : ClassMap<sysBaseRuleset>
    {

        public sysBaseRulesetMap()
        {
            Table("sys_baseruleset");
            LazyLoad();
            Id(x => x.id).GeneratedBy.Identity().Column("id");
            Map(x => x.Name).Column("Name").Length(nwdbConst.LEN_SHORT).Not.Nullable();
            Map(x => x.LongName).Column("LongName").Length(nwdbConst.LEN_LONG).Not.Nullable();
            Map(x => x.Version).Column("Version");
            Map(x => x.GPDescription).Column("DescriptionCurrency").Not.Nullable();
            Map(x => x.XPDescription).Column("DescriptionExperience").Not.Nullable();
            Map(x => x.HPDescription).Column("DescriptionLife").Not.Nullable();
            Map(x => x.StatMinimum).Column("StatMin");
            Map(x => x.StatMaximum).Column("StatMax");

            //Foreigns
            HasMany(x => x.Alignments).Cascade.All().KeyColumn("sysBaseAlignment_id");
            HasMany(x => x.CombatStats).Cascade.All().KeyColumn("sysBaseCombatStat_id");
            HasMany(x => x.DamageTypes).Cascade.All().KeyColumn("sysBaseDamageType_id");
            HasMany(x => x.Durations).Cascade.All().KeyColumn("sysBaseDurationType_id");

          }
    }
}
