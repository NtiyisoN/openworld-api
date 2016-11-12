using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using norwold.model; 
using DataModel.libHosting;


namespace DataModel.libCampaign.maps
{
    
    
    public class campCharCampaignMap : ClassMap<campCharCampaign> {
        
        public campCharCampaignMap() {
			Table("camp_char_campaigns");
			LazyLoad();
			Id(x => x.id).GeneratedBy.Identity().Column("id");
            Map(x => x.Approved);
            Map(x => x.RejectComment);

            References(x => x.Campaign).Column("campCampaign_id");
            References(x => x.Character).Column("hostChar_id");



;
        }
    }
}
