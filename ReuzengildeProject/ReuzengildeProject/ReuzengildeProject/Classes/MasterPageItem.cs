using ReuzengildeProject.Pages;
using System;
using System.Collections.Generic;

namespace ReuzengildeProject.Classes
{ 
    //Een class voor de masterpage items van de detail page die een titel en een pagina bevat
    public class MasterPageItem
    {
        public string Title { get; set; }
        public Type TargetType { get; set; }
    }
    //Een class die een list aanmaakt en bevat van masterpageitems
    public class MasterPageItems
    {
        public static List<MasterPageItem> masterPageItems = new List<MasterPageItem>()
        {
             new MasterPageItem{Title = "Home", TargetType = typeof(HomePage) },
             new MasterPageItem{Title = "Start", TargetType = typeof(OptochtPage) },
             new MasterPageItem{Title = "Deelnemers", TargetType = typeof(DeelnemersPage) },
             new MasterPageItem{Title = "Route", TargetType = typeof(RoutePage) },
             new MasterPageItem{Title = "Sponsoren", TargetType = typeof(SponsorListPage) },
             new MasterPageItem{Title = "Over", TargetType = typeof(OverPage) }
        };
    }
}
