using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Graphics.Drawable;
using Android.Views;
using Android.Widget;
using ReuzengildeProject.Droid;
using ReuzengildeProject.Pages;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android.AppCompat;
using Plugin.CurrentActivity;

[assembly: ExportRenderer(typeof(HamburgerPage), typeof(IconNavigationPageRenderer))]
namespace ReuzengildeProject.Droid
{
#pragma warning disable CS0618 // Type or member is obsolete
    public class IconNavigationPageRenderer : MasterDetailPageRenderer
    { 
        protected override void OnLayout(bool changed, int l, int t, int r, int b)
        {
            base.OnLayout(changed, l, t, r, b);
            var toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            if (toolbar != null)
            {
                for (var i = 0; i < toolbar.ChildCount; i++)
                {
                    var imageButton = toolbar.GetChildAt(i) as ImageButton;
                    var startPauzeButton = toolbar.GetChildAt(i) as ImageButton;
                    var link = toolbar.GetChildAt(i) as ImageButton;
                    var drawerArrow = imageButton?.Drawable as DrawerArrowDrawable;
                    if (drawerArrow == null)
                        continue;

                    imageButton.SetImageResource(Resource.Drawable.Hamburger);
                    link.SetImageResource(Resource.Drawable.Hamburger);

                }
            }
        }
    }
#pragma warning restore CS0618 // Type or member is obsolete
}