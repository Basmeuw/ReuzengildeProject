using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ReuzengildeProject.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HomePage : ContentPage
	{
        NavigationPage page;
		public HomePage ()
		{
			InitializeComponent ();
		}
        private async void StartButtonClicked(object sender, EventArgs e)
        {
            await Wait();
            App.HamburgerPage.Detail = page;
        }
        private async Task Wait()
        {
            page = new NavigationPage(new OptochtPage());
            
        }
	}
}