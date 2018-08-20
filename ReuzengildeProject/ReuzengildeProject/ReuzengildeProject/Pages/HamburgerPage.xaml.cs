using System;
using System.IO;
using ReuzengildeProject.Classes;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.Connectivity;
using System.Timers;

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

            IsPresented = false;
            //zorgt ervoor dat er een lijst zichtbaar is met knopjes op de detail page
            MasterPageItems.ItemsSource = Classes.MasterPageItems.masterPageItems;

        }
        //start de muziek of zet hem op pauze
        public void StartPauzeButton()
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
        //stopt de muziek
        public void StopButton()
        {
            App.DeelnemerSound.Stop();
            Console.WriteLine("Stop");
            startPauze = false;
        }
        //als je op een knopje duwd op de detailpage verandert hij de pagina en stopt de muziek.
        private void OnMenuItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            startPauze = false;
            if (e.SelectedItem == null)
            {
                return;
            }
            var item = (MasterPageItem)e.SelectedItem;
            Type page = item.TargetType;
            if (App.DeelnemerSound.IsPlaying)
            {
                App.DeelnemerSound.Pause();
            }
            CheckInformation(page);
        }
        //Deselect het knopje als je niet via de detailpage naar een pagina toe gaat
        public void DeselectListviewItems()
        {
            MasterPageItems.SelectedItem = null;
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

            ToolbarItems.Clear();
            if (page == typeof(HomePage))
            {
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
                //Detail = new NavigationPage(new GroteSponsorenPage());
                //timer = new Timer(5000);
                //timer.Start();
                //timer.Elapsed += Timer_Elapsed;

            }
            else
            {
                Detail = new NavigationPage((Page)Activator.CreateInstance(page));
            }
        }

        //private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        //{
        //    timer.Stop();
        //    optochtPage = new NavigationPage(new OptochtPage());
        //    Detail = optochtPage;
        //    if (Device.OS == TargetPlatform.Android)
        //    {
        //        AddToolBarItems();
        //    }
        //}
    }
}