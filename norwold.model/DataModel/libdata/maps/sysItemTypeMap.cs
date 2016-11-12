using System;
using System.Collections.Generic;
using System.Text;
using FluentNHibernate.Mapping;
using norwold.model;
using DataModel.libDB;


namespace DataModel.libData.maps
{


    public class sysItemTypeMap : ClassMap<sysItemType>
    {

        public sysItemTypeMap()
        {
            Table("sys_itemtypes");
            LazyLoad();
            Id(x => x.id).GeneratedBy.Identity().Column("id");
            Map(x => x.Name).Column("Name").Length(nwdbConst.LEN_SHORT).UniqueKey("sysAttribute_UK_ShortName").Not.Nullable();
            Map(x => x.LongName).Column("LongName").Length(nwdbConst.LEN_LONG).Not.Nullable();
            Map(x => x.Description).Column("description").CustomType("StringClob").CustomSqlType("nvarchar(max)");
            References(x => x.ItemType).Column("sysTreeItemType_id");
            References(x => x.Damage).Column("sysDamageRoll_id");
        }
    }
}
