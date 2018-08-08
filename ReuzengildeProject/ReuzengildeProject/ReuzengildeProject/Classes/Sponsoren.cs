using System;
using System.Collections.Generic;
using System.Text;

namespace ReuzengildeProject.Classes
{
    public class Sponsor
    {
        public string Name { get; set; }
        public string Link { get; set; }
    }
    
    public class Sponsoren
    {
        public static List<Sponsor> SponsorList = new List<Sponsor>()
        {
            new Sponsor{Name = "Historische Stoet", Link = "http://www.historischestoetroermond.nl/"}
        };
    }
}
