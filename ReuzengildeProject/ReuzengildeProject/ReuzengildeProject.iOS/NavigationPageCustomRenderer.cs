using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreGraphics;
using Foundation;
using ReuzengildeProject.iOS;
using ReuzengildeProject;
using ReuzengildeProject.Pages;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;


namespace ReuzengildeProject.iOS
{
    public class NavigationPageCustomRenderer : NavigationRenderer
    {
        //public override void ViewDidLayoutSubviews()
        //{
        //    base.ViewDidLayoutSubviews();
        //    if ((Element is HomePage homePage) || (Element is OptochtPage optochtpage))
        //    {
        //        UIButton btn1 = new UIButton(UIButtonType.Custom);
        //        UIButton btn2 = new UIButton(UIButtonType.Custom);
        //        btn1.Frame = new CGRect(0, 0, 35, 35);
        //        btn2.Frame = new CGRect(0, 0, 35, 35);
        //        var img1 = UIImage.FromFile("muziek1.png");
        //        var img2 = UIImage.FromFile("muziek2.png");
        //        btn1.SetTitle(string.Empty, UIControlState.Normal);
        //        btn2.SetTitle(string.Empty, UIControlState.Normal);
        //        btn1.SetImage(img1, UIControlState.Normal);
        //        btn2.SetImage(img2, UIControlState.Normal);
        //        btn1.TouchUpInside += (sender, e) => IconNavigationPageRenderer.hp.StartPauzeButton();
        //        btn2.TouchUpInside += (sender, e) => IconNavigationPageRenderer.hp.StopButton();
        //        var lbbi2 = new UIBarButtonItem(btn1);
        //        var lbbi3 = new UIBarButtonItem(btn2);
        //        IconNavigationPageRenderer.unc.NavigationBar.TopItem.RightBarButtonItems = new UIBarButtonItem[2]{
        //            lbbi3,
        //            lbbi2
        //    };
        //    }

        //}
    }
}
