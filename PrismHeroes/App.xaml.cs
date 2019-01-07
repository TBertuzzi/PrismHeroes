using System;
using Prism;
using Prism.DryIoc;
using Prism.Ioc;
using PrismHeroes.Services;
using PrismHeroes.ViewModels;
using PrismHeroes.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace PrismHeroes
{
    public partial class App : PrismApplication
    {
        public App()
            : this(null)
        {

        }

        public App(IPlatformInitializer initializer)
            : this(initializer, true)
        {

        }

        public App(IPlatformInitializer initializer, bool setFormsDependencyResolver)
            : base(initializer, setFormsDependencyResolver)
        {

        }


        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("/NavigationPage/CardsPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            //Automatico
            containerRegistry.RegisterForNavigation<MainPage,MainPageViewModel>();
            //Implicito
            containerRegistry.RegisterForNavigation<DetalhesPage, DetalhesViewModel>();
            containerRegistry.RegisterForNavigation<CardsPage, CardsViewModel>();

            containerRegistry.RegisterSingleton<IMarvelApiService, MarvelApiService>();
        }
    }
}
