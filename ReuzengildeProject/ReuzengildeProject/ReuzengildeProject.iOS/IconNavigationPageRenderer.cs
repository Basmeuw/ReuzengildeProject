using CoreGraphics;
using ReuzengildeProject.Pages;
using ReuzengildeProject.iOS;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(HamburgerPage), typeof(IconNavigationPageRenderer))]
namespace ReuzengildeProject.iOS
{
    public class IconNavigationPageRenderer : PhoneMasterDetailRenderer
    {
        public static UINavigationController unc;
        public static HamburgerPage hbp;
        public override void ViewDidLayoutSubviews()
        {
            base.ViewDidLayoutSubviews();
            if ((!(Element is HamburgerPage mdp)) || (!(Element is HomePage hp)) || (!(Element is OptochtPage op))) return;
            if (!(Platform.GetRenderer(mdp.Detail) is UINavigationController nc)) return;
            unc = nc;
            hbp = mdp;
            UIButton btn = new UIButton(UIButtonType.Custom);
            UIButton btn1 = new UIButton(UIButtonType.Custom);
            UIButton btn2 = new UIButton(UIButtonType.Custom);
            btn.Frame = new CGRect(0, 0, 35, 35);
            btn1.Frame = new CGRect(0, 0, 35, 35);
            btn2.Frame = new CGRect(0, 0, 35, 35);
            var img = UIImage.FromFile("Hamburger.png");
            var img1 = UIImage.FromFile("muziek1.png");
            btn1.SetTitle(string.Empty, UIControlState.Normal);
            btn1.SetImage(img1, UIControlState.Normal);
            btn1.TouchUpInside += (sender, e) => mdp.StartPauzeButton();
            var img2 = UIImage.FromFile("muziek2.png");
            btn2.SetTitle(string.Empty, UIControlState.Normal);
            btn2.SetImage(img2, UIControlState.Normal);
            btn2.TouchUpInside += (sender, e) => mdp.StopButton();
            btn.SetTitle(string.Empty, UIControlState.Normal);
            btn.SetImage(img, UIControlState.Normal);
            btn.TouchUpInside += (sender, e) => mdp.IsPresented = true;
            nc.NavigationBar.TitleTextAttributes = new UIStringAttributes()
            {
                ForegroundColor = UIColor.White
            };
            nc.NavigationBar.BarTintColor = Color.FromHex("ffffff").ToUIColor();
            var lbbi = new UIBarButtonItem(btn);
            var lbbi2 = new UIBarButtonItem(btn1);
            var lbbi3 = new UIBarButtonItem(btn2);
            nc.NavigationBar.TopItem.LeftBarButtonItem = lbbi;
            nc.NavigationBar.TopItem.RightBarButtonItems = new UIBarButtonItem[2]{
                lbbi3,
                lbbi2
            };
        }
        //public static void Test()
        //{

        //}


    }
}