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
        private List<DeelnemersPaginaItem> deelnemerPaginaItems = new List<DeelnemersPaginaItem>();
		public DeelnemersPage ()
		{
			InitializeComponent ();
            //maakt een lijst met alle deelnemers
            for(int i = 0; i < App.Information.Deelnemers.Count; i++)
            {
                deelnemerPaginaItems.Add(new DeelnemersPaginaItem { Naam = (i + 1).ToString() + " " + App.Information.Deelnemers[i].Naam });
            }
            DeelnemersList.ItemsSource = deelnemerPaginaItems;
		}
        //gaat naar de deelnemer toe die je selecteert uit de lijst
        private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var index = (DeelnemersList.ItemsSource as List<DeelnemersPaginaItem>).IndexOf(e.SelectedItem as DeelnemersPaginaItem);
            App.NumberOfDeelnemer = index + 1;
            App.HamburgerPage.ChangePage(typeof(OptochtPage));
            App.HamburgerPage.DeselectListviewItems();
        }
	}
    
}