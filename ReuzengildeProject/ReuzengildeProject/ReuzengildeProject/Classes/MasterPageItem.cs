﻿using ReuzengildeProject.Pages;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReuzengildeProject.Classes
{ 
    public class MasterPageItem
    {
        public string Title { get; set; }
        public Type TargetType { get; set; }
    }
    public class MasterPageItems
    {
        public static List<MasterPageItem> masterPageItems = new List<MasterPageItem>()
        {
             new MasterPageItem{Title = "Home", TargetType = typeof(HomePage)},
             new MasterPageItem{Title = "Start", TargetType = typeof(OptochtPage)},
             new MasterPageItem{Title = "Deelnemers", TargetType = typeof(DeelnemersPage) },
             new MasterPageItem{Title = "Route", TargetType = typeof(RoutePage) },
             new MasterPageItem{Title = "Over", TargetType = typeof(OverPage) }
        };
    }
}
