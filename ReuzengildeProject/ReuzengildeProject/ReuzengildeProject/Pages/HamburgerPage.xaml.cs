﻿using System;
using System.IO;
using ReuzengildeProject.Classes;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.Connectivity;

namespace ReuzengildeProject.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HamburgerPage : MasterDetailPage
    {
        private Page homePage = new NavigationPage(new HomePage());
        private Page optochtPage;
        private bool startPauze = false;
        public HamburgerPage()
        {
            InitializeComponent();

            ChangePage(typeof(HomePage));

            IsPresented = false;
            MasterPageItems.ItemsSource = Classes.MasterPageItems.masterPageItems;
        }
        private void StartPauzeButton()
        {
            startPauze = !startPauze;
                if (startPauze)
                {
                    App.DeelnemerSound.Play();
                }
                else if (!startPauze)
                {
                    App.DeelnemerSound.Pause();
                }
        }
        private void StopButton()
        {
            App.DeelnemerSound.Stop();
            startPauze = false;
        }
        private async void OnMenuItemSelected(object sender, SelectedItemChangedEventArgs e)
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
                        await DisplayAlert("Error", "Maak eerst verbinding met het internet om de laatste informatie op te halen en probeer dan opnieuw.", "Oké");
                    }
                }
            }
            else
            {
                ChangePage(page);
                IsPresented = false;
            }
        }
        public void DeselectListviewItems()
        {
            MasterPageItems.SelectedItem = null;
        }
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
        public void ChangePage(Type page)
        {
            ToolbarItems.Clear();
            if (page == typeof(HomePage))
            {
                Detail = homePage;
                AddToolBarItems();
            } else if(page == typeof(OptochtPage))
            {
                optochtPage = new NavigationPage(new OptochtPage());
                Detail = optochtPage;
                AddToolBarItems();
            } else
            {
                Detail = new NavigationPage((Page)Activator.CreateInstance(page));
            }
        }
    }
}