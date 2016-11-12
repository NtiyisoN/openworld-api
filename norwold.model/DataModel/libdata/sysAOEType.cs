using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataModel.libDB;


namespace DataModel.libData
{
    public class sysAOEType : nwdbDataType
    {
        public virtual bool isCone { get; set; }
        public virtual bool isRay { get; set; }
        public virtual bool isCircle { get; set; }

        //Copy Constructor;
        public sysAOEType()
            : base()
        {
        }
        public sysAOEType(string n, string nl) : base(n, nl) { }

        public sysAOEType(string n, string nl,bool cone, bool ray, bool circle) : base(n, nl) {
            this.isCone = cone;
            this.isRay = ray;
            this.isCircle = circle;
        }

        public static void SeedListData(IList<sysAOEType> aoetypes)
        {
            //AOETypes
            aoetypes.Add(new sysAOEType("Cone", "Cone", true, false, false));
            aoetypes.Add(new sysAOEType("Touch", "Touch"));
            aoetypes.Add(new sysAOEType("Ray", "Ray", false, true, false));
            aoetypes.Add(new sysAOEType("Sphere", "Sphere", false, false, true));  
        }
    }
}
