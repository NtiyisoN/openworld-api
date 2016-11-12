using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using norwold.model; 

namespace norwold.model.maps {
    
    
    public class ConstSysRangeMap : ClassMap<ConstSysRange> {
        
        public ConstSysRangeMap() {
			Table("const_sys_range");
			LazyLoad();
			Id(x => x.id).GeneratedBy.Identity().Column("id");
            Map(x => x.Name).Column("Name").Not.Nullable().Length(10);
            Map(x => x.LongName).Column("LongName").Not.Nullable().Length(10);
			Map(x => x.range_base).Column("range_base").Not.Nullable();
			Map(x => x.range_units).Column("range_units").Not.Nullable();
			Map(x => x.range_per).Column("range_per").Not.Nullable();
			Map(x => x.range_perName).Column("range_perName").Not.Nullable();
			Map(x => x.range_perdivide).Column("range_perdivide").Not.Nullable();
        }
    }
}
