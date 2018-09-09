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
	public partial class SponsorPage : ContentPage
	{
		public SponsorPage ()
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
                Device.OpenUri(new Uri("https://www.absautoherstel.nl/site/vestigingen/provincie/limburg/peterbrouwers"));
            }
        }

        private async void TapGestureRecognizer_Tapped1(object sender, EventArgs e)
        {
            bool GoToSite = await DisplayAlert("Melding", "Wilt u doorgaan naar de site van dit bedrijf of deze persoon?", "Ja", "Nee");
            if (GoToSite)
            {
                Device.OpenUri(new Uri("http://www.arsprintmedia.nl/"));
            }
        }
        private async void TapGestureRecognizer_Tapped2(object sender, EventArgs e)
        {
            bool GoToSite = await DisplayAlert("Melding", "Wilt u doorgaan naar de site van dit bedrijf of deze persoon?", "Ja", "Nee");
            if (GoToSite)
            {
                Device.OpenUri(new Uri("https://www.bizroermond.nl/"));
            }
        }
        private async void TapGestureRecognizer_Tapped3(object sender, EventArgs e)
        {
            bool GoToSite = await DisplayAlert("Melding", "Wilt u doorgaan naar de site van dit bedrijf of deze persoon?", "Ja", "Nee");
            if (GoToSite)
            {
                Device.OpenUri(new Uri("https://coxenco.com/"));
            }
        }
        private async void TapGestureRecognizer_Tapped4(object sender, EventArgs e)
        {
            bool GoToSite = await DisplayAlert("Melding", "Wilt u doorgaan naar de site van dit bedrijf of deze persoon?", "Ja", "Nee");
            if (GoToSite)
            {
                Device.OpenUri(new Uri("https://www.gs-advocatuur.nl/"));
            }
        }
        private async void TapGestureRecognizer_Tapped5(object sender, EventArgs e)
        {
            await DisplayAlert("Melding","Dit bedrijf of deze persoon heeft geen site.", "Oké");
        }
        private async void TapGestureRecognizer_Tapped6(object sender, EventArgs e)
        {
            bool GoToSite = await DisplayAlert("Melding", "Wilt u doorgaan naar de site van dit bedrijf of deze persoon?", "Ja", "Nee");
            if (GoToSite)
            {
                Device.OpenUri(new Uri("http://www.incognitoroermond.nl/"));
            }
        }
        private async void TapGestureRecognizer_Tapped7(object sender, EventArgs e)
        {
            bool GoToSite = await DisplayAlert("Melding", "Wilt u doorgaan naar de site van dit bedrijf of deze persoon?", "Ja", "Nee");
            if (GoToSite)
            {
                Device.OpenUri(new Uri("https://www.moorenmachines.nl/"));
            }
        }
        private async void TapGestureRecognizer_Tapped8(object sender, EventArgs e)
        {
            bool GoToSite = await DisplayAlert("Melding", "Wilt u doorgaan naar de site van dit bedrijf of deze persoon?", "Ja", "Nee");
            if (GoToSite)
            {
                Device.OpenUri(new Uri("https://www.nettt.nl/"));
            }
        }
        private async void TapGestureRecognizer_Tapped9(object sender, EventArgs e)
        {
            bool GoToSite = await DisplayAlert("Melding", "Wilt u doorgaan naar de site van dit bedrijf of deze persoon?", "Ja", "Nee");
            if (GoToSite)
            {
                Device.OpenUri(new Uri("https://www.theaterhotelroermond.nl/"));
            }
        }
        private async void TapGestureRecognizer_Tapped10(object sender, EventArgs e)
        {
            bool GoToSite = await DisplayAlert("Melding", "Wilt u doorgaan naar de site van dit bedrijf of deze persoon?", "Ja", "Nee");
            if (GoToSite)
            {
                Device.OpenUri(new Uri("https://www.cultuurfonds.nl/provinciale-afdelingen/limburg"));
            }
        }
        private async void TapGestureRecognizer_Tapped11(object sender, EventArgs e)
        {
            bool GoToSite = await DisplayAlert("Melding", "Wilt u doorgaan naar de site van dit bedrijf of deze persoon?", "Ja", "Nee");
            if (GoToSite)
            {
                Device.OpenUri(new Uri("https://www.rockwool.nl/"));
            }
        }
        private async void TapGestureRecognizer_Tapped12(object sender, EventArgs e)
        {
            bool GoToSite = await DisplayAlert("Melding", "Wilt u doorgaan naar de site van dit bedrijf of deze persoon?", "Ja", "Nee");
            if (GoToSite)
            {
                Device.OpenUri(new Uri("http://www.rotraco.nl/"));
            }
        }
    }
}