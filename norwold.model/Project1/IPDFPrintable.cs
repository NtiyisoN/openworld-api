using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace norwold.printing
{
    /**
     *  Core interface for PDF Printing
     * 
     * 
     * 
     * 
     * 
     * 
     * 
     * */
    
    public interface IPDFPrintable
    {
   
        //Style enumeration options
        public abstract int Layout { get; set; }

        //Total number of Sections
        public abstract int Sections { get; set; }
        
        //return styles for PDF
        public libCSS GetStyles();

        //return next text Section
        public string EnumSections(int nextSection);


    }
}
