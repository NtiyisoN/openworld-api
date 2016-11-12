using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using norwold.model;
using DataModel.libDB;


namespace DataModel.libData.maps
{


    public class sysLanguageMap : ClassMap<sysLanguage>
    {

        public sysLanguageMap()
        {
            Table("sys_languages");
            LazyLoad();
            Id(x => x.id).GeneratedBy.Identity().Column("id");
            Map(x => x.Name).Column("Name").Length(nwdbConst.LEN_SHORT).UniqueKey("sysLanguage_UK_ShortName").Not.Nullable();
            Map(x => x.LongName).Column("LongName").Length(nwdbConst.LEN_LONG).UniqueKey("sysLanguage_UK_LongName").Not.Nullable();

            HasMany(x => x.Milestones).Cascade.All().KeyColumn("sysLanguage_id");
        }
    }
}
