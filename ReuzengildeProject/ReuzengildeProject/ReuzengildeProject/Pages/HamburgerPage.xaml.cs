using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReuzengildeProject.Classes;
using ReuzengildeProject.Pages;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.Connectivity;

namespace ReuzengildeProject.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HamburgerPage : MasterDetailPage
    {
        public HamburgerPage()
        {
            InitializeComponent();

            Detail = new NavigationPage(new HomePage());

            IsPresented = false;

            MasterPageItems.ItemsSource = Classes.MasterPageItems.masterPageItems;
        }
        private async void OnMenuItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
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
            if (page == typeof(OptochtPage) || page == typeof(DeelnemersPage))
            {
                if (File.Exists(App.Path) && App.Information != null)
                {
                    Detail = new NavigationPage((Page)Activator.CreateInstance(page));
                    IsPresented = false;
                }
                else if (File.Exists(App.Path) && App.Information == null)
                {
                    App.Information = DatabaseController.GetJson(App.Path);
                    Detail = new NavigationPage((Page)Activator.CreateInstance(page));
                    IsPresented = false;
                }
                else if (!File.Exists(App.Path))
                {
                    if (CrossConnectivity.Current.IsConnected)
                    {
                        await DatabaseController.SaveFile(App.Path);
                        Detail = new NavigationPage((Page)Activator.CreateInstance(page));
                        IsPresented = false;
                        App.LatestInformation = true;
                    }
                    else
                    {
                        await DisplayAlert("Error", "Maak eerst verbinding met het internet om de laatste informatie op te halen en probeer dan opnieuw.", "Oké");
                    }
                }
            }
            else
            {
                Detail = new NavigationPage((Page)Activator.CreateInstance(page));
                IsPresented = false;
            }
        }
        public void DeselectListviewItems()
        {
            MasterPageItems.SelectedItem = null;
        }
    }
}