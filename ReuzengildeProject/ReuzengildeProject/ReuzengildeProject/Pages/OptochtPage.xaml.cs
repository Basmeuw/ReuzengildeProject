using System;
using System.Timers;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ReuzengildeProject.Classes;

namespace ReuzengildeProject.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class OptochtPage : ContentPage
	{
        private int NumberOfDeelnemers;
        DateTime dt;
        DateTime dateTime;
        Timer timer;
        public OptochtPage ()
		{

            InitializeComponent();
            //checkt of het een ios device is en zorgt er dan voor dat de detail page open gaat en weer sluit zodat hij de iconnavigationpagerenderer gebruikt zodat
            //het hamburgermenu en de geluidsknopjes zichtbaar worden omdat dit niet werkte als je niet via een van de knopjes via de detail page naar een pagina toe gaat 
            //maar vanuit het start knopje of de deelnemerslijst
            if (Device.OS == TargetPlatform.iOS)
            {
                App.HamburgerPage.IsPresented = true;
                App.HamburgerPage.IsPresented = false;
            }

            if (!App.StartOptocht)
            {
                Console.WriteLine("test");
                Timer();
                try
                {
                    Console.WriteLine(App.Information.Deelnemers[App.NumberOfDeelnemer - 1].Bestandnaam.ToString());
                    DeelnemersImage.Source = App.Information.Deelnemers[App.NumberOfDeelnemer - 1].Bestandnaam + ".jpg";
                }
                catch { }
                NaamDeelnemer.Text = App.Information.Deelnemers[App.NumberOfDeelnemer - 1].Naam;
            }
            else if (App.StartOptocht)
            {
                Console.WriteLine("3");
                ChangeItems();
            }
            try
            {
                App.DeelnemerSound.Load( App.Information.Deelnemers[App.NumberOfDeelnemer - 1].Bestandnaam + ".mp3");
            }
            catch
            {

            }


        }

        public void Timer()
        {
            timer = new Timer(1000);
                timer.Elapsed += async (sender, e) => await SetTimer();
                timer.Start();
        }

        async Task SetTimer()
        {
            

            dateTime = new DateTime(2018, 8, 9, 13, 30, 0);
            dt = DateTime.Now.ToLocalTime();
            dt = DateTime.ParseExact(dt.ToString("yyyy-MM-dd HH:mm:ss"), "yyyy-MM-dd HH:mm:ss", null);
            if (dt >= dateTime)
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    App.StartOptocht = true;
                    BackButton.IsEnabled = true;
                    NextButton.IsEnabled = true;
                    NumberOfDeelnemer.IsEnabled = true;
                    ChangeItems();
                    timer.Stop();
                });
            }
            else
            {
                Device.BeginInvokeOnMainThread(() =>
                {

                    InformatieDeelnemer.Text = "nog " + (dateTime - dt).ToString() + " tot de optocht!";
                    App.StartOptocht = false;
                    BackButton.IsEnabled = false;
                    NextButton.IsEnabled = false;
                    NumberOfDeelnemer.IsEnabled = false;
                });
            }
        }

        public void ChangeItems()
        {

            //zet muziek op het geluidsknopje en de foto op het scherm
            try
            {
                Console.WriteLine(App.Information.Deelnemers[App.NumberOfDeelnemer - 1].Bestandnaam.ToString());
                DeelnemersImage.Source = App.Information.Deelnemers[App.NumberOfDeelnemer - 1].Bestandnaam + ".jpg";
            }
            catch { }
            //checkt er nog deelnemers beschikbaar zijn zodat je als er geen hogere deelnemers meer zijn niet verder kunt klikken
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
            //verandert alle informatie op het scherm naar informatie uit de database.
            NaamDeelnemer.Text = App.Information.Deelnemers[App.NumberOfDeelnemer - 1].Naam;
            NumberOfDeelnemer.Text = App.NumberOfDeelnemer.ToString();
            InformatieDeelnemer.Text = App.Information.Deelnemers[App.NumberOfDeelnemer - 1].Beschrijving;
            App.DeelnemerSound.Stop();
            App.HamburgerPage.startPauze = false;
            scrollView.ScrollToAsync(0, 0, false);

        }
        //gaat een deelnemer terug
        private void BackButtonClicked(object sender, EventArgs e)
        {
            if(App.NumberOfDeelnemer > 1)
            {
                App.NumberOfDeelnemer -= 1;
                ChangeItems();
            }

        }
        //gaat een deelnemer verder
        private void NextButtonClicked(object sender, EventArgs e)
        {
            App.NumberOfDeelnemer += 1;
            App.DeelnemerSound.Stop();
            ChangeItems();
        }
        //als je een nummer intypt op de entry onderin het scherm kijkt hij of dit nummer bestaat
        private void ChangeNumberOfDeelnemers(object sender, TextChangedEventArgs e)
        {
            NumberOfDeelnemers = 0;
            try
            {
                NumberOfDeelnemers = int.Parse(NumberOfDeelnemer.Text);
            }
            catch { }
            if (NumberOfDeelnemers >= 1 && NumberOfDeelnemers <= App.Information.Deelnemers.Count)
            {
                App.NumberOfDeelnemer = NumberOfDeelnemers;
                ChangeItems();
            }
            else
            {
                DisplayAlert("Sorry", "Het maximale aantal deelnemers is " + (App.Information.Deelnemers.Count).ToString(), "Oké");
                NumberOfDeelnemer.Text = App.NumberOfDeelnemer.ToString();
            }
        }
        //als je op de entry klikt word hij leeg zodat je een nieuw nummer kan intypen
        private void EntryFocused(object sender, TextChangedEventArgs e)
        {
            NumberOfDeelnemer.Text = string.Empty;
        }
    }
}