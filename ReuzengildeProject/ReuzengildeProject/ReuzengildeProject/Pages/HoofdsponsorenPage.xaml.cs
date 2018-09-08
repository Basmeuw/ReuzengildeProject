using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ReuzengildeProject.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HoofdsponsorenPage : ContentPage
    {
		public HoofdsponsorenPage ()
		{
			InitializeComponent ();
            if (Device.OS == TargetPlatform.iOS)
            {
                App.HamburgerPage.IsPresented = true;
                App.HamburgerPage.IsPresented = false;
            }

        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            bool GoToSite = await DisplayAlert("Melding", "Wilt u doorgaan naar de site van dit bedrijf of deze persoon?", "Ja", "Nee");
            if (GoToSite)
            {
                Device.OpenUri(new Uri("https://www.roermond.nl/"));
            }
        }

        private async void TapGestureRecognizer_Tapped1(object sender, EventArgs e)
        {
            bool GoToSite = await DisplayAlert("Melding", "Wilt u doorgaan naar de site van dit bedrijf of deze persoon?", "Ja", "Nee");
            if (GoToSite)
            {
                Device.OpenUri(new Uri("https://www.limburg.nl/"));
            }
        }

        private async void TapGestureRecognizer_Tapped2(object sender, EventArgs e)
        {
            bool GoToSite = await DisplayAlert("Melding", "Wilt u doorgaan naar de site van dit bedrijf of deze persoon?", "Ja", "Nee");
            if (GoToSite)
            {
                Device.OpenUri(new Uri("http://www.historischestoetroermond.nl/"));
            }
        }

        private async void TapGestureRecognizer_Tapped3(object sender, EventArgs e)
        {
            bool GoToSite = await DisplayAlert("Melding", "Wilt u doorgaan naar de site van dit bedrijf of deze persoon?", "Ja", "Nee");
            if (GoToSite)
            {
                Device.OpenUri(new Uri("https://www.rabobank.nl/lokale-bank/roermond-echt/"));
            }
        }

        private async void TapGestureRecognizer_Tapped4(object sender, EventArgs e)
        {
            bool GoToSite = await DisplayAlert("Melding", "Wilt u doorgaan naar de site van dit bedrijf of deze persoon?", "Ja", "Nee");
            if (GoToSite)
            {
                Device.OpenUri(new Uri("https://www.hoteldux.nl/nl/"));
            }
        }

        private async void TapGestureRecognizer_Tapped5(object sender, EventArgs e)
        {
            bool GoToSite = await DisplayAlert("Melding", "Wilt u doorgaan naar de site van deze Hoofdsponsor?", "Ja", "Nee");
            if (GoToSite)
            {
                Device.OpenUri(new Uri(" http://www.stichting1880.nl/home.html "));
            }

        }
    }
}