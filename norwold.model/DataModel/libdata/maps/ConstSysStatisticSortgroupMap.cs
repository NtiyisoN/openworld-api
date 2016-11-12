using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using norwold.model; 

namespace norwold.model.maps {
    
    
    public class ConstSysStatisticSortGroupMap : ClassMap<ConstSysStatisticSortGroup> {
        
        public ConstSysStatisticSortGroupMap() {
			Table("const_sys_statistic_sortgroup");
			LazyLoad();
			Id(x => x.id).GeneratedBy.Identity().Column("id");
			Map(x => x.Name).Column("Name").Not.Nullable().Length(10);
            Map(x => x.LongName).Column("LongName").Not.Nullable().Length(10);

        }
    }
}
