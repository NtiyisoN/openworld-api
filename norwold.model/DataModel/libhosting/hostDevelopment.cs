using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using norwold.model;
using DataModel.libDB;


namespace DataModel.libHosting
{
    public class hostDevelopment : nwdbDataType
    {

        public hostDevelopment() { }

        public virtual String Type { get; set; }
        public virtual String Description { get; set; }
        public virtual DateTime Created { get; set; }
        public virtual String Version{ get; set; }
        public virtual bool Closed { get; set; }

    }
}
