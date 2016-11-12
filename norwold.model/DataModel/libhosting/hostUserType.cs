using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using norwold.model;
using DataModel.libDB;


namespace DataModel.libHosting
{
    [Serializable()]
    public class hostUserType : nwdbDataType
    {
         public hostUserType() : base() {
             this.Email = "all-logons@norwold.org";
             //Users = new List<hostUser>();
        }
 
        public hostUserType(string n,string nl):base(n,nl) {
            this.Email = "all-logons@norwold.org";
            //Users = new List<hostUser>();
        }
        

        public virtual string Email { get; set; }
        public virtual string Description { get; set; }
        // public virtual IList<hostUser> Users { get; set; }

 
    }
}
