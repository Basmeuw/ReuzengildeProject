using Xamarin.Forms;
using ReuzengildeProject.Classes;
using ReuzengildeProject.Pages;
using Plugin.Connectivity;
using System.IO;
using Plugin.SimpleAudioPlayer;
using Plugin.SimpleAudioPlayer.Abstractions;

namespace ReuzengildeProject
{
    public partial class App : Application
	{
        public static string Path;
        public static int NumberOfDeelnemer { get; set; }
        public static HamburgerPage HamburgerPage { get; set; }
        public static JsonToCs Information { get; set; }
        public static bool LatestInformation { get; set; }
        public static ISimpleAudioPlayer BackgroundSound = CrossSimpleAudioPlayer.CreateSimpleAudioPlayer();
        public static ISimpleAudioPlayer DeelnemerSound = CrossSimpleAudioPlayer.CreateSimpleAudioPlayer();

        public App (string path)
		{
            AddResources();
            NumberOfDeelnemer = 1;
            Path = path;
            if (CrossConnectivity.Current.IsConnected)
            {
                DatabaseController.SaveJsonLocal(Path);
                LatestInformation = true;
            }
            else if(File.Exists(Path))
            {
                DatabaseController.GetJson(Path);
                LatestInformation = false;
            }
            else
            {
                LatestInformation = false;
            }
            InitializeComponent();
            HamburgerPage = new HamburgerPage();
            MainPage = HamburgerPage;
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}

        private void AddResources()
        {
            Current.Resources = new ResourceDictionary
            {
                { "UlycesColor", Color.FromHex("ffffff") }
            };
            var navigationStyle = new Style(typeof(NavigationPage));
            var barBackgroundColorSetter = new Setter { Property = NavigationPage.BarBackgroundColorProperty, Value = Color.FromHex("ffffff") };
            navigationStyle.Setters.Add(barBackgroundColorSetter);
            Current.Resources.Add(navigationStyle);
        }
	}
}
