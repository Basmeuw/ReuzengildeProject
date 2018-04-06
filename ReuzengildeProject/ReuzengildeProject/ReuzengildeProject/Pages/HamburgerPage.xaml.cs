using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReuzengildeProject.Classes;
using ReuzengildeProject.Pages;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ReuzengildeProject.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HamburgerPage : MasterDetailPage
	{
		public HamburgerPage ()
		{
            InitializeComponent();

            Detail = new NavigationPage(new HomePage());

            IsPresented = false;

            MasterPageItems mpi = new MasterPageItems();
            MasterPageItems.ItemsSource = mpi.masterPageItems;
        }
        private void OnMenuItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = (MasterPageItem)e.SelectedItem;
            Type page = item.TargetType;

            Detail = new NavigationPage((Page)Activator.CreateInstance(page));
            IsPresented = false;
        }
    }
}