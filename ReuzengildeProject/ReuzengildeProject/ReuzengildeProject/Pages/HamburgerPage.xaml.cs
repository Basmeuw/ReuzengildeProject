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
        public List<MasterPageItem> MasterPageItemsList { get; set; }
		public HamburgerPage ()
		{
            InitializeComponent();

            Detail = new NavigationPage(new HomePage());

            IsPresented = false;

            MasterPageItemsList = new List<MasterPageItem>();
            MasterPageItemsList.Add(MakeMasterPageItem("Home", typeof(HomePage)));
            MasterPageItemsList.Add(MakeMasterPageItem("Start", typeof(OptochtPage)));
            MasterPageItemsList.Add(MakeMasterPageItem("Deelnemers", typeof(DeelnemersPage)));
            MasterPageItemsList.Add(MakeMasterPageItem("Route", typeof(RoutePage)));
            MasterPageItemsList.Add(MakeMasterPageItem("Over", typeof(OverPage)));
            MasterPageItems.ItemsSource = MasterPageItemsList;
        }
        private void OnMenuItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = (MasterPageItem)e.SelectedItem;
            Type page = item.TargetType;

            Detail = new NavigationPage((Page)Activator.CreateInstance(page));
            IsPresented = false;
        }
        private MasterPageItem MakeMasterPageItem(string title, Type targetType)
        {
            MasterPageItem page = new MasterPageItem() { Title = title, TargetType = targetType };
            return page;
        }
    }
}