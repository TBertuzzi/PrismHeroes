using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace PrismHeroes.Views
{
    public partial class MenuPage :  TabbedPage
    {
        public MenuPage()
        {
            InitializeComponent();

            On<Xamarin.Forms.PlatformConfiguration.iOS>().SetUseSafeArea(true);

            Children.Add(new MainPage());
            Children.Add(new CardsPage());

        }
    }
}
