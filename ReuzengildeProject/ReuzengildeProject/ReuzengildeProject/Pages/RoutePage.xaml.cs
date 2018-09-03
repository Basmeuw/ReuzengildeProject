using System;
using System.Xml;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.Internals;

namespace ReuzengildeProject.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RoutePage : ContentPage
    {
        public RoutePage()
        {         
            Content = new Grid
            {
                Padding = new Thickness(20),
                Children = {
        new PinchToZoomContainer {
          Content = new Image { Source = ImageSource.FromFile ("Route.jpg") }
        }
      }
            };

            InitializeComponent();
        }
    }
}
       




