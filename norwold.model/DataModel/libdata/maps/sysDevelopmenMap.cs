using System;
using System.Collections.Generic;
using System.Text;
using FluentNHibernate.Mapping;
using norwold.model;
using DataModel.libDB;


namespace DataModel.libData.maps
{


    public class sysDevelopmentMap : ClassMap<sysDevelopment>
    {

        public sysDevelopmentMap()
        {
            Table("sys_development");
            LazyLoad();
            Id(x => x.id).GeneratedBy.Identity().Column("id");
            Map(x => x.Name).Column("Name").Length(nwdbConst.LEN_SHORT).Not.Nullable();
            Map(x => x.LongName).Column("LongName").Length(nwdbConst.LEN_LONG).Not.Nullable();
            Map(x => x.Description).Column("description").CustomType("StringClob").CustomSqlType("nvarchar(max)");
            References(x => x.DevelopmentGroup).Column("sysTreeDevelopment_id");
            HasMany(x => x.XPSpent).Inverse().Cascade.All();
            
            HasMany(x => x.Milestones).Cascade.All().KeyColumn("sysDevelopment_id");

        }
    }
}
