using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using norwold.model;
using DataModel.libHosting;
using DataModel.libDB;


namespace DataModel.libCampaign

{
    [Serializable()]
    public class campCampaign : nwdbDataType
    {

        
        public campCampaign(): base()
        {
            //5Characters = new List<campCharCampaign>();
            Adventures = new List<campAdventure>();
            if (this.DateStarted == DateTime.MinValue) { this.DateStarted = nwdbConst.minSQLDate; }
            if (this.DateFinished == DateTime.MinValue) { this.DateFinished = nwdbConst.minSQLDate; }
        }

        public campCampaign(string n, string nl)
            : this()
        {
            this.Name = n.Substring(0, Math.Min(nwdbConst.LEN_SHORT , n.Length ));
            this.LongName = nl.Substring(0, Math.Min(nwdbConst.LEN_LONG , nl.Length ));

        }
        
        public campCampaign(string n, string nl, string email, hostUser gm, DateTime start, DateTime finish, string desc)
            : this(n,nl)
        {
            this.Email = email;
            this.DateStarted = start;
            this.DateFinished = finish;
            this.GM = gm;
            this.Description = desc;
        }

        public virtual string Description { get; set; }
        public virtual string Email { get; set; }
        public virtual hostUser GM { get; set; }
        public virtual DateTime DateStarted { get; set; }
        public virtual DateTime DateFinished { get; set; }
        //public virtual IList<campCharCampaign> Characters { get; set; }
        public virtual IList<campAdventure> Adventures { get; set; }

 

    }
}