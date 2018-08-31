using Android.App;
using Android.Content.PM;
using Android.OS;
using System.IO;

namespace ReuzengildeProject.Droid
{
    [Activity(Label = "Historische stoet", 
        Theme = "@style/MainTheme",  
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, ScreenOrientation = ScreenOrientation.Portrait)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);

            string folder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string filePath = Path.Combine(folder, "Data.json");

            Xamarin.Forms.Forms.Init(this, bundle);

            LoadApplication(new App(filePath));
        }
    }
}

