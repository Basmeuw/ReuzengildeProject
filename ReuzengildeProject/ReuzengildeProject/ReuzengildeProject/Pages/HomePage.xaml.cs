using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ReuzengildeProject.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HomePage : ContentPage
	{
		public HomePage ()
		{
		//zet muziek op het muziek knopje
            try
            {
                App.DeelnemerSound.Load("akkermansgildevenlo.mp3");
            }
            catch
            {

            }

            InitializeComponent ();
		}
		//checkt of er informatie is voor de optochtpage en gaat er dan naartoe
        private void StartButtonClicked(object sender, EventArgs e)
        {
            App.HamburgerPage.CheckInformation(typeof(OptochtPage));
            App.HamburgerPage.DeselectListviewItems();
        }
	}
}
