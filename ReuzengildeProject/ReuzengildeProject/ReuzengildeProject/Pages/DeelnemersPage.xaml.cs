using System;
using System.Collections.Generic;
using ReuzengildeProject.Classes;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ReuzengildeProject.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DeelnemersPage : ContentPage
	{
		public DeelnemersPage ()
		{
			InitializeComponent ();
            //maakt een lijst met alle deelnemers
            DeelnemersList.ItemsSource = App.Information.Deelnemers;
		}
        //gaat naar de deelnemer toe die je selecteert uit de lijst
        private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var index = (DeelnemersList.ItemsSource as List<Deelnemer>).IndexOf(e.SelectedItem as Deelnemer);
            Console.WriteLine(index.ToString());
            App.NumberOfDeelnemer = index + 1;
            App.HamburgerPage.ChangePage(typeof(OptochtPage));
            App.HamburgerPage.DeselectListviewItems();
        }
	}
}