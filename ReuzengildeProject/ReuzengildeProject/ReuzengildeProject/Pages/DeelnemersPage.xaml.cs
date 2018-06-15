using System;
using System.Collections.Generic;
using ReuzengildeProject.Classes;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ReuzengildeProject.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DeelnemersPage : ContentPage
	{
		public DeelnemersPage ()
		{
			InitializeComponent ();
            //maakt een lijst met alle deelnemers
            DeelnemersList.ItemsSource = App.Information.Deelnemers;
		}
        //gaat naar de deelnemer toe die je selecteert uit de lijst
        private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var index = (DeelnemersList.ItemsSource as List<Deelnemer>).IndexOf(e.SelectedItem as Deelnemer);
            Console.WriteLine(index.ToString());
            App.NumberOfDeelnemer = index + 1;
            App.HamburgerPage.ChangePage(typeof(OptochtPage));
            App.HamburgerPage.DeselectListviewItems();
        }
	}
    public class ExtendedScrollView : ScrollView
    {
        public event Action<ScrollView, Rectangle> Scrolled;

        public void UpdateBounds(Rectangle bounds)
        {
            Position = bounds.Location;
            if (Scrolled != null)
                Scrolled(this, bounds);
        }

        public static readonly BindableProperty PositionProperty =
            BindableProperty.Create<ExtendedScrollView, Point>(
                p => p.Position, default(Point));

        public Point Position
        {
            get { return (Point)GetValue(PositionProperty); }
            set { SetValue(PositionProperty, value); }
        }

        public static readonly BindableProperty AnimateScrollProperty =
            BindableProperty.Create<ExtendedScrollView, bool>(
                p => p.AnimateScroll, true);

        public bool AnimateScroll
        {
            get { return (bool)GetValue(AnimateScrollProperty); }
            set { SetValue(AnimateScrollProperty, value); }
        }
    }
}