using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReuzengildeProject.Classes;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ReuzengildeProject.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class VriendenPage : ContentPage
	{
		public VriendenPage ()
		{

			InitializeComponent ();
            if (Device.OS == TargetPlatform.iOS)
            {
                App.HamburgerPage.IsPresented = true;
                App.HamburgerPage.IsPresented = false;
            }

            VriendenList.ItemsSource = Vrienden.VriendenList;
        }

        private async void VriendenList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var index = (VriendenList.ItemsSource as List<Vriend>).IndexOf(e.SelectedItem as Vriend);
            if(Vrienden.VriendenList[index].Link != string.Empty)
            {
                bool GoToSite = await DisplayAlert("Melding", "Wilt u doorgaan naar de site van dit bedrijf of deze persoon?", "Ja", "Nee");
                if (GoToSite)
                {
                    Device.OpenUri(new Uri(Vrienden.VriendenList[index].Link));
                }
                App.HamburgerPage.ChangePage(typeof(VriendenPage));
            }
            else if(Vrienden.VriendenList[index].Link == string.Empty)
            {
                await DisplayAlert("Sorry", "Dit bedrijf of deze persoon heeft geen site!", "Oké");
            }

        }
    }
}