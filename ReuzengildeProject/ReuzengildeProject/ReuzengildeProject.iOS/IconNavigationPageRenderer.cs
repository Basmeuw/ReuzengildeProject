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
            if ((!(Element is HamburgerPage hamburgerPage))) return;
            if (!(Platform.GetRenderer(hamburgerPage.Detail) is UINavigationController navigationController)) return;

            UIButton btn = new UIButton(UIButtonType.Custom);
            UIButton btn1 = new UIButton(UIButtonType.Custom);
            UIButton btn2 = new UIButton(UIButtonType.Custom);
            UIButton btn3 = new UIButton(UIButtonType.Custom);

            btn.Frame = new CGRect(0, 0, 35, 35);
            btn1.Frame = new CGRect(0, 0, 35, 35);
            btn2.Frame = new CGRect(0, 0, 35, 35);
            btn3.Frame = new CGRect(0, 0, 35, 35);

            var img = UIImage.FromFile("Hamburger.png");
            var img1 = UIImage.FromFile("muziek1.png");
            var img2 = UIImage.FromFile("muziek2.png");
            var img3 = UIImage.FromFile("link.jpg");

            btn.SetTitle(string.Empty, UIControlState.Normal);
            btn.SetImage(img, UIControlState.Normal);
            btn.TouchUpInside += (sender, e) => hamburgerPage.IsPresented = true;

            btn1.SetTitle(string.Empty, UIControlState.Normal);
            btn1.SetImage(img1, UIControlState.Normal);
            btn1.TouchUpInside += (sender, e) => hamburgerPage.StartPauzeButton();

            btn2.SetTitle(string.Empty, UIControlState.Normal);
            btn2.SetImage(img2, UIControlState.Normal);
            btn2.TouchUpInside += (sender, e) => hamburgerPage.StopButton();

            btn3.SetTitle(string.Empty, UIControlState.Normal);
            btn3.SetImage(img3, UIControlState.Normal);
            btn3.TouchUpInside += (sender, e) => hamburgerPage.LinkButton();

            navigationController.NavigationBar.TitleTextAttributes = new UIStringAttributes()
            {
                ForegroundColor = UIColor.White
            };
            navigationController.NavigationBar.BarTintColor = Color.FromHex("ffffff").ToUIColor();

            var lbbi = new UIBarButtonItem(btn);
            var lbbi2 = new UIBarButtonItem(btn1);
            var lbbi3 = new UIBarButtonItem(btn2);
            var lbbi4 = new UIBarButtonItem(btn3);

            navigationController.NavigationBar.TopItem.LeftBarButtonItem = lbbi;
            navigationController.NavigationBar.TopItem.RightBarButtonItems = new UIBarButtonItem[3]{
                lbbi3,
                lbbi2,
                lbbi4
            };
        }
    }
}