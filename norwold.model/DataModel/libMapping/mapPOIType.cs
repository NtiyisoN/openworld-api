using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading.Tasks;
using System.Resources;
using System.Diagnostics;
using norwold.model;
using DataModel.libDB;




namespace DataModel.libMapping
{
    public class mapPOIType : mapDataTypeDraw
    {

        //constructors
        public mapPOIType() : base() {  }
        public mapPOIType(string n,string nl) : base(n,nl) {  }
        public mapPOIType(string n,string nl,string resname,string importname,int stepc, int priority) 
                : base(n,nl,resname,importname,true,0,0,stepc,Color.White,priority)
        {
            Debug.Print("Loaded POI" + nl + " using resource" + resname + " Resultant Bitmap width:" + this.Tile.Size.Width + "height" + this.Tile.Size.Height);
         }

        public mapPOIType(string n, string nl, string resname, string importname, int stepc, int priority,mapTreePOI tPOI)
            : base(n, nl, resname, importname, true, 0, 0, stepc, Color.White, priority)
        {
            Debug.Print("Loaded POI by TreeLoad using treeleaf:"+tPOI.Name);
            this.POIGroup = tPOI;
        }

        
        public virtual mapTreePOI POIGroup { get; set; } 
    }


}
