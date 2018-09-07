using Plugin.Connectivity;
using ReuzengildeProject.Classes;
using System;
using System.IO;
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

            InitializeComponent();

            App.HomePage = true;
            Console.WriteLine(App.HomePage.ToString());
		//zet muziek op het muziek knopje
            try
            {
                App.HomePageSound.Load("Instructie.mp3");
                Console.WriteLine("Werkt");
            }
            catch
            {

            }

        }
		//checkt of er informatie is voor de optochtpage en gaat er dan naartoe
        private void StartButtonClicked(object sender, EventArgs e)
        {
            App.HamburgerPage.CheckInformation(typeof(OptochtPage));
            App.HamburgerPage.DeselectListviewItems();
        }
	}
}
