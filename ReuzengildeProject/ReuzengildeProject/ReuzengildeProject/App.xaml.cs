using Xamarin.Forms;
using ReuzengildeProject.Classes;
using ReuzengildeProject.Pages;
using Plugin.Connectivity;
using System.IO;
using Plugin.SimpleAudioPlayer;
using Plugin.SimpleAudioPlayer.Abstractions;
using System;

namespace ReuzengildeProject
{
    public partial class App : Application
	{
        public static string Path;

        //het nummer van de deelnemer waar je bent op de informatie pagina
        public static int NumberOfDeelnemer { get; set; }

        //een reference naar de hamburger page zodat je vanuit andere scripts dingen kan aan passen op de hamburgerpage.
        public static HamburgerPage HamburgerPage { get; set; }

        //een reference naar de class JsonToCs met een list met de informatie uit de database. 
        public static JsonToCs Information { get; set; }

        public static bool LatestInformation { get; set; }

        //Een reference naar het background geluid voor als ze dit laterna nog willen.
        public static ISimpleAudioPlayer HomePageSound = CrossSimpleAudioPlayer.CreateSimpleAudioPlayer();

        //Een reference naar het geluid van de deelnemer op de deelnemers page.
        public static ISimpleAudioPlayer DeelnemerSound;

        public static bool StartOptocht;

        public static bool StartSponsorFoto = true;

        public static bool HomePage = false;
        //Gebeurt wanneer de app word opgestart en checkt of er een internet connectie is. Als er een internet connectie is haalt hij de informatie uit de database. 
        //Ook start hij de eerste pagina van de app.
        public App (string path)
		{
            AddResources();
            NumberOfDeelnemer = 1;
            Path = path;
            InitializeComponent();
            HamburgerPage = new HamburgerPage();
            MainPage = HamburgerPage;
            if (CrossConnectivity.Current.IsConnected)
            {
                DatabaseController.SaveJsonLocal(Path);
                LatestInformation = true;
            }
            else if (File.Exists(Path))
            {
                DatabaseController.GetJson(Path);
                LatestInformation = false;
            }
            else
            {
                LatestInformation = false;
            }
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

        //zorgt ervoor dat de navigation bar wit is 
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
