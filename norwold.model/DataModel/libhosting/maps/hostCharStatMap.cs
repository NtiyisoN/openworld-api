using System;
using System.Collections.Generic;
using System.Text;
using FluentNHibernate.Mapping;
using norwold.model;

namespace DataModel.libHosting.maps
{


    public class hostCharStatMap : ClassMap<hostCharStat>
    {

        public hostCharStatMap()
        {
            Table("host_charstats");
            Id(x => x.id).GeneratedBy.Identity().Column("id");
            Map(x => x.value).Column("value").Not.Nullable();
            References(x => x.stat).UniqueKey("hostCharStat_UK_statchar");
            References(x => x.character).UniqueKey("hostCharStat_UK_statchar");
          }
    }
}
