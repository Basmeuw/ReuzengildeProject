using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReuzengildeProject.Classes;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ReuzengildeProject.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class VriendenPage : ContentPage
	{
		public VriendenPage ()
		{

			InitializeComponent ();
            VriendenList.ItemsSource = Vrienden.VriendenList;
        }

        private void VriendenList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var index = (VriendenList.ItemsSource as List<Vriend>).IndexOf(e.SelectedItem as Vriend);
            Device.OpenUri(new Uri(Vrienden.VriendenList[index].Link));
        }
    }
}