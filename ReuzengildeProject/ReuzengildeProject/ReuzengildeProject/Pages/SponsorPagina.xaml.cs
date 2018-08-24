using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReuzengildeProject.Pages;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ReuzengildeProject.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SponsorPagina : ContentPage
	{
		public SponsorPagina()
		{
			InitializeComponent ();
          //  SponsorenList.ItemsSource = Sponsoren.SponsorList;
		}
        public void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
           // var index = (SponsorenList.ItemsSource as List<Sponsor>).IndexOf(e.SelectedItem as Sponsor);
           // Device.OpenUri(new Uri(Sponsoren.SponsorList[index].Link));
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            App.HamburgerPage.ChangePage(typeof(HoofdsponsorenPage));
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {

        }

        private void Button_Clicked_2(object sender, EventArgs e)
        {
            App.HamburgerPage.ChangePage(typeof(VriendenPage));
        }
    }
}