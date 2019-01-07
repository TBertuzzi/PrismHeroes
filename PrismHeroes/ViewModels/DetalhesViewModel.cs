using System;
using Prism.Navigation;
using Prism.Services;
using PrismHeroes.Models.MarvelHeroesCN.Models;

namespace PrismHeroes.ViewModels
{
    public class DetalhesViewModel : ViewModelBase
    {
        private Personagem Personagem { get; set; }

        protected DetalhesViewModel(INavigationService navigationService,
                IPageDialogService pageDialogService) : base(navigationService, pageDialogService)
        {
            Title = "Detalhes";

        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {

            if (parameters.ContainsKey("personagem"))
                Personagem = (Personagem)parameters["personagem"];
                
        }
    }
}
