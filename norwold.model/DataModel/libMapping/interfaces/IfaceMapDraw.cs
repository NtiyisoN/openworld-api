using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;


namespace DataModel.libMapping.interfaces
{
    /**
     * Defines the functions needed for a class to be drawable on System graphics
     * Its implementation is concerned only with Drawing and Route cost via FOV/StepHeight
     * Many thanks to Peter Geerkins for the original implementation via Hex Tools
     * 
     * Currently assumes the following:
     *      Hexes are /4 not /3 factored  ((in line with Redtools Hex guidelines))
     *      
     *      Canvas will be square with the hex contained within; 
     *          backgrounds are transparent and fill the canvas
     *          Foregrouds must be transparent and will be dimensioned to canvas (so cant be full drawn into corners)
     *          This means they bleeed over slightly if they fill their Tile in the corners
     *  
     *      1pt margin for the boundaries / hex line to be drawn
     *      
     *      Layering:
     *          Terrain Background Fill
     *          Terrain Foreground Fill
     *          Terrain Mods (( Rivers,roads,rail) Foreground draw
     *          POIs Foreground draw  ((based upon the layer priority (and visible POI list) only the highest will be drawn with a + to show a drill down))
     * **/

    public interface IfaceMapDraw
    {
        //Properties
        SolidBrush brBackground { get; set; }       //Background [fill] - optional;
        TextureBrush brForeground { get; set; }     //Foreground [texture] - optional - but usual;
        Bitmap Tile { get; set; }                   // holds the fullsize image, provides (scaled) texturebrushes via brForeground/brBackground
        Color bgColor { get; set; }                 // holds the background colour [fill]
        int LayerPriority { get; set; }             // determines for non terrain types, who gets layered on top
        
        //Navigable stuff
        int Elevation { get; set; }                 //Elevation for FOV
        int HeightTerrain { get; set; }             //Height for FOV
        int StepCost { get; set; }                  //StepCost for navigate
       
        //methods
        void SetBrush(Size s, bool transposed);     // Resize Foreground Brush
        void PrintHex(Size s, Graphics g);          // Draw Image on graphicsG
   

       
    }
}
