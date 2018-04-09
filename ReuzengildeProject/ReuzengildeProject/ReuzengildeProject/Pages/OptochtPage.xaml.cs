using ReuzengildeProject.Classes;
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
	public partial class OptochtPage : ContentPage
	{
        public OptochtPage ()
		{
            InitializeComponent ();
            ChangeItems();
        }
        public void ChangeItems()
        {
            if (App.NumberOfDeelnemer == 1)
            {
                BackButton.IsEnabled = false;
            }
            if (App.NumberOfDeelnemer == App.Information.Deelnemers.Count)
            {
                NextButton.IsEnabled = false;
            }
            if (App.NumberOfDeelnemer > 1)
            {
                BackButton.IsEnabled = true;
            }
            if (App.NumberOfDeelnemer < App.Information.Deelnemers.Count)
            {
                NextButton.IsEnabled = true;
            }
            NaamDeelnemer.Text = App.Information.Deelnemers[App.NumberOfDeelnemer - 1].Naam;
            NumberOfDeelnemer.Text = App.NumberOfDeelnemer.ToString();
        }
        private void BackButtonClicked(object sender, EventArgs e)
        {
            if(App.NumberOfDeelnemer > 1)
            {
                App.NumberOfDeelnemer -= 1;
                ChangeItems();
            }

        }
        private void NextButtonClicked(object sender, EventArgs e)
        {
            App.NumberOfDeelnemer += 1;
            ChangeItems();
        }
        private void ChangeNumberOfDeelnemers(object sender, TextChangedEventArgs e)
        {
            int NumberOfDeelnemers = int.Parse(NumberOfDeelnemer.Text);
            if(NumberOfDeelnemers >= 1 && NumberOfDeelnemers <= App.Information.Deelnemers.Count)
            {
                App.NumberOfDeelnemer = NumberOfDeelnemers;
                ChangeItems();
            }
            else
            {
                DisplayAlert("Error", "Kies een nummer tussen 1 en " + (App.Information.Deelnemers.Count).ToString(), "Oké");
                NumberOfDeelnemer.Text = App.NumberOfDeelnemer.ToString();
            }
        }
        private void EntryFocused(object sender, TextChangedEventArgs e)
        {
            NumberOfDeelnemer.Text = string.Empty;
        }
    }
}