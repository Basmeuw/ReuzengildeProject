using System;
using System.IO;
using ReuzengildeProject.Classes;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.Connectivity;
using System.Timers;
using System.Windows.Input;

namespace ReuzengildeProject.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HamburgerPage : MasterDetailPage
    {
        private Page homePage = new NavigationPage(new HomePage());
        private Page optochtPage;
        public bool startPauze = false;
        private Timer timer;
        public HamburgerPage()
        {
            InitializeComponent();
            //detailpage naar de homepage
            ChangePage(typeof(HomePage));
            App.HomePage = true;

            IsPresented = false;
            //zorgt ervoor dat er een lijst zichtbaar is met knopjes op de detail page
            MasterPageItems.ItemsSource = Classes.MasterPageItems.masterPageItems;

        }
        //start de muziek of zet hem op pauze
        public void StartPauzeButton()
        {
            if (App.HomePage)
            {
                startPauze = !startPauze;
                if (startPauze)
                {
                    Console.WriteLine("play");
                    App.HomePageSound.Play();
                }
                else if (!startPauze)
                {
                    Console.WriteLine("Pauze");
                    App.HomePageSound.Pause();
                }
            }

            else
            {
                startPauze = !startPauze;
                if (startPauze)
                {
                    Console.WriteLine("play");
                    App.DeelnemerSound.Play();
                }
                else if (!startPauze)
                {
                    Console.WriteLine("Pauze");
                    App.DeelnemerSound.Pause();
                }
            }

        }
        //stopt de muziek
        public void StopButton()
        {
            if(App.HomePageSound.IsPlaying || App.DeelnemerSound.IsPlaying)
            if (App.HomePage)
            {
                App.HomePageSound.Stop();
                Console.WriteLine("Stop");
                startPauze = false;
            }
            else
            {
                App.DeelnemerSound.Stop();
                Console.WriteLine("Stop");
                startPauze = false;
            }


        }
        //als je op een knopje duwd op de detailpage verandert hij de pagina en stopt de muziek.
        private void OnMenuItemSelected(object sender, SelectedItemChangedEventArgs e)
        {


            if (e.SelectedItem == null)
            {
                return;
            }
            var item = (MasterPageItem)e.SelectedItem;
            Type page = item.TargetType;

            CheckInformation(page);
        }
        //Deselect het knopje als je niet via de detailpage naar een pagina toe gaat
        public void DeselectListviewItems()
        {
            MasterPageItems.SelectedItem = null;
        }

        //Iets met de link
        public async void LinkButton()
        {
            if (App.Information.Deelnemers[App.NumberOfDeelnemer - 1].Link == null || App.Information.Deelnemers[App.NumberOfDeelnemer - 1].Link == string.Empty)
            {
                await DisplayAlert("Melding", "Deze deelnemer heeft geen site", "Oké");
            }
            else
            {
                bool GoToSite = await DisplayAlert("Melding", "Wilt u doorgaan naar de site van deze deelnemer?", "Ja", "Nee");
                if (GoToSite)
                {
                    Device.OpenUri(new Uri(App.Information.Deelnemers[App.NumberOfDeelnemer - 1].Link));
                }
            }


        }
      
        
        //voegt de geluidsknopjes toe
        private void AddToolBarItems()
        {
            ToolbarItem tbi = new ToolbarItem

            {
                Icon = "muziek1.png",
                Order = ToolbarItemOrder.Primary,
                Command = new Command(() => StartPauzeButton())
            };
            ToolbarItem tbi2 = new ToolbarItem
            {
                Icon = "muziek2.png",
                Order = ToolbarItemOrder.Primary,
                Command = new Command(() => StopButton())
            };
            ToolbarItem tbi3 = new ToolbarItem
            {
                Icon = "link.jpg",
                Order = ToolbarItemOrder.Primary,
                Command = new Command( () => LinkButton())
            };
            ToolbarItems.Add(tbi3);
            ToolbarItems.Add(tbi);
            ToolbarItems.Add(tbi2);
        }

        //checkt of er informatie opgeslagen is op de app zodat de app niet crashed
        public async void CheckInformation(Type page)
        {
            if (page == typeof(OptochtPage) || page == typeof(DeelnemersPage))
            {
                if (File.Exists(App.Path) && App.Information != null)
                {
                    ChangePage(page);
                    IsPresented = false;
                }
                else if (File.Exists(App.Path) && App.Information == null)
                {
                    App.Information = DatabaseController.GetJson(App.Path);
                    ChangePage(page);
                    IsPresented = false;
                }
                else if (!File.Exists(App.Path))
                {
                    if (CrossConnectivity.Current.IsConnected)
                    {
                        await DatabaseController.SaveFile(App.Path);
                        ChangePage(page);
                        IsPresented = false;
                        App.LatestInformation = true;
                    }
                    else
                    {
                        await DisplayAlert("Sorry", "Maak eerst verbinding met het internet om de meest recente informatie op te halen en probeer het dan opnieuw.", "Oké");
                    }
                }
            }
            else
            {
                ChangePage(page);
                IsPresented = false;
            }
        }
        //veranderd de detail page 
        public void ChangePage(Type page)
        {
            startPauze = false;
            App.HomePage = false;
            try
            {
                if (App.DeelnemerSound.IsPlaying)
                {
                    App.DeelnemerSound.Stop();
                }

            }
            catch { }
            try
            {
                if (App.HomePageSound.IsPlaying)
                {
                    App.HomePageSound.Stop();
                }
            }
            catch { }
           
            ToolbarItems.Clear();
            if (page == typeof(HomePage))
            {
                App.HomePage = true;
                Detail = homePage;
                if(Device.OS == TargetPlatform.Android)
                {
                    AddToolBarItems();
                }
            }
            else if(page == typeof(OptochtPage))
            {
                optochtPage = new NavigationPage(new OptochtPage());
                Detail = optochtPage;
                if (Device.OS == TargetPlatform.Android)
                {
                    AddToolBarItems();
                }

            }
            else
            {
                Detail = new NavigationPage((Page)Activator.CreateInstance(page));
            }
        }
    }
}