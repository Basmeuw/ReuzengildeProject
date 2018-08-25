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

        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            App.HamburgerPage.ChangePage(typeof(HoofdsponsorenPage));
            App.HamburgerPage.DeselectListviewItems();
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            App.HamburgerPage.ChangePage(typeof(SponsorPage));
            App.HamburgerPage.DeselectListviewItems();
        }

        private void Button_Clicked_2(object sender, EventArgs e)
        {
            App.HamburgerPage.ChangePage(typeof(VriendenPage));
            App.HamburgerPage.DeselectListviewItems();
        }
    }
}