using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using ReuzengildeProject.Classes;
using ReuzengildeProject.Pages;
using Plugin.Connectivity;
using System.IO;

namespace ReuzengildeProject
{
	public partial class App : Application
	{
        public static string Path;
        public static int NumberOfDeelnemer { get; set; }
        public static HamburgerPage HamburgerPage { get; set; }
        public static JsonToCs Information { get; set; }
        public static bool LatestInformation { get; set; }

        public App (string path)
		{
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
	}
}
