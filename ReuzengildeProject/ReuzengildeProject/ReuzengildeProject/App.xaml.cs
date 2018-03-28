﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using ReuzengildeProject.Classes;
using ReuzengildeProject.Pages;

namespace ReuzengildeProject
{
	public partial class App : Application
	{
        public static string Path;

		public App (string path)
		{
            //test
            Path = path;
            DatabaseController.SaveJsonLocal(Path);
            InitializeComponent();
            MainPage = new NavigationPage(new HamburgerPage());
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
