using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using norwold.model;
using DataModel.libDB;


namespace DataModel.libData.maps
{
    public class nwItemMap : ClassMap<nwItem>
    {
        public nwItemMap()
        {
            Table("nw_item");
            LazyLoad();
            Id(x => x.id).GeneratedBy.Identity().Column("id");
            Map(x => x.Name).Column("Name").Length(nwdbConst.LEN_SHORT);
            Map(x => x.LongName).Column("LongName").Length(nwdbConst.LEN_LONG);
            Map(x => x.Description).Column("description").CustomType("StringClob").CustomSqlType("nvarchar(max)");
            References(x => x.Owner).Column("hostChar_id");
            Map(x => x.Bonus).Column("Bonus");

            HasMany(x => x.Milestones).Cascade.All().KeyColumn("nwItem_id");
            
            References(x => x.ItemType);
        }
    }
}
