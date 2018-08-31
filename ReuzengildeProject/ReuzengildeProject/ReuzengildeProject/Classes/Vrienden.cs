using System;
using System.Collections.Generic;
using System.Text;

namespace ReuzengildeProject.Classes
{
    public class Vriend
    {
        public string Name { get; set; }
        public string Link { get; set; }
    }
    
    public class Vrienden
    {
        public static List<Vriend> VriendenList = new List<Vriend>()
        {
            new Vriend{Name = "Sif", Link = "https://sif-group.com/nl/"},
            new Vriend{Name = "Horecaondernemers Stationsplein", Link = string.Empty},
            new Vriend{Name = "Sligro", Link = "https://www.sligro.nl/"},
            new Vriend{Name = "Tjeu Linssen Mode in Wonen en Slapen", Link = "https://www.tjeulinssen.nl/"},
            new Vriend{Name = "Red Security", Link = "http://www.redsecurity.nl/"},
            new Vriend{Name = "Installatiebedrijf G. Sars BV", Link = "http://gsars.nl/"},
            new Vriend{Name = "Geelen Bouw", Link = "http://www.geelen.nl/"},
            new Vriend{Name = "Smurfit Kappa Roermond Papier", Link = "https://www.smurfitkappa.com/vHome/nl/Roermond"},
            new Vriend{Name = "La joie du vin", Link = "http://www.lajoieduvin.nl/"},
            new Vriend{Name = "Lyceum Schöndeln", Link = "https://www.lyceumschondeln.nl/"},
            new Vriend{Name = "PSW", Link = "http://psw.nl/"},
            new Vriend{Name = "Bisdom Roermond", Link = "http://www.bisdom-roermond.nl/"},
            new Vriend{Name = "'t Paradies", Link = "https://www.paradiesroermond.nl/"},
            new Vriend{Name = "Het Ondernemersplein Limburg", Link = "http://www.ondernemerspleinlimburg.nl/"},
            new Vriend{Name = "LLTB", Link = "https://www.lltb.nl/home"},
            new Vriend{Name = "Pierre Rutten Interieurbouw", Link = "http://www.pierrerutteninterieurbouw.nl/"},
            new Vriend{Name = "Christoffelgilde", Link = "https://nl-nl.facebook.com/StChristoffelgildeRoermond/"},
            new Vriend{Name = "Gerard Nizet", Link = "http://nl.gnizet.com/"},
            new Vriend{Name = "René Imkamp", Link = string.Empty},
            new Vriend{Name = "Wim Kemp", Link = string.Empty},
        };
    }
}
