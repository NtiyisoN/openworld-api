using System;
using System.Collections.Generic;
using System.Text;
using FluentNHibernate.Mapping;
using norwold.model;
using DataModel.libDB;


namespace DataModel.libData.maps
{


    public class sysFactionRankingMap : ClassMap<sysFactionRanking>
    {

        public sysFactionRankingMap()
        {
            Table("sys_factionranks");
            LazyLoad();
            Id(x => x.id).GeneratedBy.Identity().Column("id");
            Map(x => x.Name).Column("Name").Length(nwdbConst.LEN_SHORT).Not.Nullable();
            Map(x => x.LongName).Column("LongName").Length(nwdbConst.LEN_LONG).Not.Nullable();
            Map(x => x.FactionPoints).Column("required_points");
            Map(x => x.Effects).Column("effects").CustomType("StringClob").CustomSqlType("nvarchar(max)");
            
            //References(x => x.StatisticGroup);
        }
    }
}
