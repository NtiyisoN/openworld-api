using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using norwold.model;
using DataModel.libDB;


namespace DataModel.libData.maps
{


    public class sysDamageRollMap : ClassMap<sysDamageRoll>
    {

        public sysDamageRollMap()
        {
            Table("sys_dmgrolls");
            LazyLoad();
            Id(x => x.id).GeneratedBy.Identity().Column("id");
            Map(x => x.Name).Column("Name").Length(nwdbConst.LEN_SHORT).Not.Nullable();
            Map(x => x.LongName).Column("LongName").Length(nwdbConst.LEN_LONG).Not.Nullable();
            Map(x => x.Die).UniqueKey("dmgroll_UK_allfields");
            Map(x => x.Number).UniqueKey("dmgroll_UK_allfields");
            Map(x => x.Bonus).UniqueKey("dmgroll_UK_allfields");
            Map(x => x.PerDivide).UniqueKey("dmgroll_UK_allfields");
            References(x => x.BonusPer).Column("sysStatistic_id").UniqueKey("dmgroll_UK_allfields");
            HasMany(x => x.ItemsDamage).Inverse().Cascade.All();
        }
    }
}
