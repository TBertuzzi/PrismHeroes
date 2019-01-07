using System;
using Prism.Navigation;
using Prism.Services;

namespace PrismHeroes.ViewModels
{
    public class MenuViewModel : ViewModelBase
    {
    
        protected MenuViewModel(INavigationService navigationService,
                IPageDialogService pageDialogService) : base(navigationService, pageDialogService)
        {


        }

       
    }
}
