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
            try
            {
                App.DeelnemerSound.Load("Pokemon.mp3");
            }
            catch
            {

            }

            InitializeComponent ();
		}
        private void StartButtonClicked(object sender, EventArgs e)
        {
            App.HamburgerPage.CheckInformation(typeof(OptochtPage));
        }
	}
}