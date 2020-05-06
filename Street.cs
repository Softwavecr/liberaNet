using System;
using System.Text.Json;
using J = System.Text.Json.Serialization.JsonPropertyNameAttribute;

namespace liberaNet
{
    public class Street
    {
        public int id { get; set; }
        [J("name")]
        public string name { get; set; }
        [J("startx")]
        public double startx { get; set; }
        [J("starty")]
        public double starty  { get; set; }
        [J("endx")]
        public double endx { get; set; }
        [J("endy")]
        public double endy { get; set; }
        
    public Street(string pname, double pstartx, double pstarty, double pendx, double pendy)
    {
        name = pname; 
        startx = pstartx;
        starty = pstarty;
        endx = pendx;
        endy = pendy;
    }        
        public Street()
    {
        name = ""; 
        startx = 0;
        starty = 0;
        endx = 0;
        endy = 0;
    } 
    }
}
