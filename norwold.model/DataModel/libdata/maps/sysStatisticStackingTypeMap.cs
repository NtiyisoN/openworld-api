using System;
using System.Collections.Generic;
using System.Text;
using FluentNHibernate.Mapping;
using norwold.model;
using DataModel.libDB;


namespace DataModel.libData.maps
{


    public class sysStatisticStackingTypeMap : ClassMap<sysStatisticStackingType>
    {

        public sysStatisticStackingTypeMap()
        {
            Table("sys_stats_stacking");
            LazyLoad();
            Id(x => x.id).GeneratedBy.Identity().Column("id");
            Map(x => x.Name).Column("Name").Length(nwdbConst.LEN_SHORT);
            Map(x => x.LongName).Column("LongName").Length(nwdbConst.LEN_LONG).Not.Nullable();
            


            References(x => x.Statistic).Column("sysStatistic_id");
            References(x => x.ItemType).Column("sysTreeItemType_id");
        }
    }
}
