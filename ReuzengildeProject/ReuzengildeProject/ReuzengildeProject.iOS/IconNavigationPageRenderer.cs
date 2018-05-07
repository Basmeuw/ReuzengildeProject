﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreGraphics;

using ReuzengildeProject.Pages;
using Foundation;
using ReuzengildeProject.iOS;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(HamburgerPage), typeof(IconNavigationPageRenderer))]
namespace ReuzengildeProject.iOS
{
    public class IconNavigationPageRenderer : PhoneMasterDetailRenderer
    {
        public override void ViewDidLayoutSubviews()
        {
            base.ViewDidLayoutSubviews();
            if (!(Element is HamburgerPage mdp)) return;
            if (!(Platform.GetRenderer(mdp.Detail) is UINavigationController nc)) return;

            UIButton btn = new UIButton(UIButtonType.Custom);
            btn.Frame = new CGRect(0, 0, 40, 55);
            var img = UIImage.FromFile("Hamburger.png");
            btn.SetTitle(string.Empty, UIControlState.Normal);
            btn.SetImage(img, UIControlState.Normal);
            btn.TouchUpInside += (sender, e) => mdp.IsPresented = true;
            nc.NavigationBar.TitleTextAttributes = new UIStringAttributes()
            {
                ForegroundColor = UIColor.White
            };
            //test
            nc.NavigationBar.BarTintColor = Color.FromHex("ffffff").ToUIColor();

            var lbbi = new UIBarButtonItem(btn);
            nc.NavigationBar.TopItem.LeftBarButtonItem = lbbi;
        }
        
    }
}