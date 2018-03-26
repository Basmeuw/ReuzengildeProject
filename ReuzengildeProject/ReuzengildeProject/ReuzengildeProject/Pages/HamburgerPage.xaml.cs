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
            
            Detail = new HomePage();
            IsPresented = false;

			InitializeComponent ();
		}
        void HomeButtonClicked(object sender, EventArgs e)
        {
            Detail = new HomePage();
            IsPresented = false;
        }
        void OptochtButtonClicked(object sender, EventArgs e)
        {
            Detail = new OptochtPage();
            IsPresented = false;
        }
        void DeelnemersButtonClicked(object sender, EventArgs e)
        {
            Detail = new DeelnemersPage();
            IsPresented = false;
        }
        void RouteButtonClicked(object sender, EventArgs e)
        {
            Detail = new RoutePage();
            IsPresented = false;
        }
        void OverButtonClicked(object sender, EventArgs e)
        {
            Detail = new OverPage();
            IsPresented = false;
        }
    }
}