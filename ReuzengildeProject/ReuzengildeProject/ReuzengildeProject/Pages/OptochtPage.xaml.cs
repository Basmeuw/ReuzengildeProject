using System;
using System.Timers;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Threading;
using System.Collections.Generic;

namespace ReuzengildeProject.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class OptochtPage : ContentPage
	{

        private List<string> enkelvoud = new List<string>()
        {
            " uur, ",
            " minuut en ",
            " seconde "
        };

        private List<string> meervoud = new List<string>()
        {
            " uren, ",
            " minuten en ",
            " seconden "
        };

        private List<string> timerText = new List<string>()
        {
            "",
            "",
            ""
        };

        private int NumberOfDeelnemers;

        private DateTime localTime;
        private DateTime optochtTime;

        private System.Timers.Timer optochtTimer;
        public OptochtPage ()
		{



            InitializeComponent();
            Thread thread = new Thread(() =>
            {
                
                Thread thread1 = new Thread(() =>
                {
                    for(int i = 0; i < 3; i++)
                    {
                        Thread.Sleep(1000);
                        Device.BeginInvokeOnMainThread(() =>
                        {
                            if (int.Parse(SponsorText.Text) != 0)
                            {
                                SponsorText.Text = (int.Parse(SponsorText.Text) - 1).ToString();
                            }
                            else if(int.Parse(SponsorText.Text) == 0)
                            {
                                SponsorText.Text = "0";
                            }
                        });
                    }
                });
                thread1.Start();
                Thread.Sleep(3000);
                Device.BeginInvokeOnMainThread(() =>
                {
                    Content.IsVisible = true;
                    Image.IsVisible = false;
                });

            });
            thread.Start();
            //checkt of het een ios device is en zorgt er dan voor dat de detail page open gaat en weer sluit zodat hij de iconnavigationpagerenderer gebruikt zodat
            //het hamburgermenu en de geluidsknopjes zichtbaar worden omdat dit niet werkte als je niet via een van de knopjes via de detail page naar een pagina toe gaat 
            //maar vanuit het start knopje of de deelnemerslijst
            if (Device.OS == TargetPlatform.iOS)
            {
                App.HamburgerPage.IsPresented = true;
                App.HamburgerPage.IsPresented = false;
            }

            if (App.Information.Deelnemers[App.NumberOfDeelnemer - 1].Naam.Length > 30)
            {
                NaamDeelnemer.FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label));
            }
            else
            {
                NaamDeelnemer.FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label));
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
            catch{}
        }

        private void UpdateSponsorenText()
        {

        }

        public void Timer()
        {
            optochtTimer = new System.Timers.Timer(1000);
            optochtTimer.Elapsed += async (sender, e) => await SetTimer();
            optochtTimer.Start();
        }

        async Task SetTimer()
        {
            optochtTime = new DateTime(2018, 8, 28, 17, 00, 0);

            localTime = DateTime.Now.ToLocalTime();
            localTime = DateTime.ParseExact(localTime.ToString("yyyy-MM-dd HH:mm:ss"), "yyyy-MM-dd HH:mm:ss", null);

            if (localTime >= optochtTime)
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    App.StartOptocht = true;
                    BackButton.IsEnabled = true;
                    NextButton.IsEnabled = true;
                    NumberOfDeelnemer.IsEnabled = true;
                    ChangeItems();
                    optochtTimer.Stop();
                });
            }
            else
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    if((optochtTime - localTime).Days > 0)
                    { 
                        InformatieDeelnemer.Text = "De Historische Stoet vindt plaats op 9 September 2018. Dit betekent dat het nog maar " + (optochtTime - localTime).Days.ToString() + " dagen is totdat alle informatie over de Historische Stoet beschikbaar wordt! \nVanaf dat moment zal u hier de informatie over de deelnemers kunnen lezen!";
                    }
                    else if((optochtTime - localTime).Days <= 0)
                    {
                        CheckTime(optochtTime, localTime);
                        InformatieDeelnemer.Text = "De Historische Stoet vindt plaats op 9 September 2018. Dit betekent dat het nog maar " + (optochtTime - localTime).Hours.ToString() + timerText[0] + (optochtTime - localTime).Minutes.ToString() + timerText[1] + (optochtTime - localTime).Seconds.ToString() + timerText[2] + "is totdat alle informatie over de Historische Stoet beschikbaar wordt! \nVanaf dat moment zal u hier de informatie over de deelnemers kunnen lezen!";
                    }
                    App.StartOptocht = false;
                    BackButton.IsEnabled = false;
                    NextButton.IsEnabled = false;
                    NumberOfDeelnemer.IsEnabled = false;
                });
            }
        }

        private void CheckTime(DateTime optochtTime, DateTime localTime)
        {
            List<int> dateTimes = new List<int>()
            {
                (optochtTime - localTime).Hours,
                (optochtTime - localTime).Minutes,
                (optochtTime - localTime).Seconds
            };
            for(int i = 0; i < dateTimes.Count; i++)
            {
                if(dateTimes[i] != 1)
                {
                    timerText[i] = meervoud[i];
                }
                else if(dateTimes[i] == 1 || dateTimes[i] == 0)
                {
                    timerText[i] = enkelvoud[i];
                }
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
            if (App.Information.Deelnemers[App.NumberOfDeelnemer - 1].Naam.Length > 30)
            {
                NaamDeelnemer.FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label));
            }
            else
            {
                NaamDeelnemer.FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label));
            }
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

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            bool GoToGroteSponsorPage =  await DisplayAlert("Melding", "Wilt u naar de pagina van de grote sponsoren gaan?", "Ja", "Nee");
            if (GoToGroteSponsorPage)
            {
                App.HamburgerPage.ChangePage(typeof(HoofdsponsorenPage));
                App.HamburgerPage.DeselectListviewItems();
            }
            else if (!GoToGroteSponsorPage)
            {
                Content.IsVisible = true;
                Image.IsVisible = false;
            }
        }
    }
}