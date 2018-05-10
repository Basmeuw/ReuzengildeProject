using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ReuzengildeProject.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class OverPage : ContentPage
	{
		public OverPage ()
		{
			InitializeComponent ();
		}
        public void Test(object sender, EventArgs e)
        {
            DisplayAlert("test", "Werkt", "Oké");
            Console.WriteLine("Test");
        }
    }
}