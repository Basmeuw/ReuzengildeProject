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
	public partial class SponsorListPage : ContentPage
	{
		public SponsorListPage()
		{
			InitializeComponent ();
            SponsorenList.ItemsSource = Sponsoren.SponsorList;
		}
        public void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var index = (SponsorenList.ItemsSource as List<Sponsor>).IndexOf(e.SelectedItem as Sponsor);
            Device.OpenUri(new Uri(Sponsoren.SponsorList[index].Link));
        }
	}
}