using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using norwold.model;
using DataModel.libDB;



namespace DataModel.libData.maps
{
    public class sysAOETypeMap : ClassMap<sysAOEType>
    {
        public sysAOETypeMap()
        {
            Table("sys_aoetype");
            LazyLoad();
            Id(x => x.id).GeneratedBy.Identity().Column("id");
            Map(x => x.Name).Column("Name").Length(nwdbConst.LEN_SHORT);
            Map(x => x.LongName).Column("LongName").Length(nwdbConst.LEN_LONG).UniqueKey("sysAOEType_LongName");
            Map(x => x.isCone);
            Map(x => x.isRay);
            Map(x => x.isCircle);

        }
    }
}
