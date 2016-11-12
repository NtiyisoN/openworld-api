using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using norwold.model;
using DataModel.libDB;


namespace DataModel.libData.maps
{


    public class sysMilestoneTypeMap : ClassMap<sysMilestoneType>
    {

        public sysMilestoneTypeMap()
        {
            Table("sys_milestonestypes");
            LazyLoad();
            Id(x => x.id).GeneratedBy.Identity().Column("id");
            Map(x => x.Name).Column("Name").Length(nwdbConst.LEN_SHORT).Not.Nullable();
            Map(x => x.LongName).Column("LongName").Length(nwdbConst.LEN_LONG).Not.Nullable();
            Map(x => x.isCharMandatory);
            Map(x => x.isFactionMandatory);
            Map(x => x.isHexMandatory);
            Map(x => x.isItemMandatory);
            Map(x => x.isDevPathMandatory);
            Map(x => x.isLanguageMandatory);
            Map(x => x.isPOIMandatory);

            
            HasMany(x => x.MileStoneTree).Inverse().Cascade.All().KeyColumn("sysMilestoneType_id");

        }
    }
}
