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
	public partial class DeelnemersPage : ContentPage
	{
		public DeelnemersPage ()
		{
			InitializeComponent ();
            DeelnemersList.ItemsSource = App.Information.Deelnemers;
		}
        private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var index = (DeelnemersList.ItemsSource as List<Classes.Deelnemer>).IndexOf(e.SelectedItem as Classes.Deelnemer);
            Console.WriteLine(index.ToString());
            App.NumberOfDeelnemer = index + 1;
            App.HamburgerPage.Detail = new NavigationPage(new OptochtPage());
            App.HamburgerPage.DeselectListviewItems();
        }
	}
}