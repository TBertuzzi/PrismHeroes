using System;
using Prism.Navigation;
using Prism.Services;
using PrismHeroes.Models.MarvelHeroesCN.Models;

namespace PrismHeroes.ViewModels
{
    public class DetalhesViewModel : ViewModelBase
    {

        private Personagem _personagem;
        public Personagem Personagem
        {
            get => _personagem;
            set => SetProperty(ref _personagem, value);
        }

        protected DetalhesViewModel(INavigationService navigationService,
                IPageDialogService pageDialogService) : base(navigationService, pageDialogService)
        {
            Title = "Detalhes";

        }

        public override void OnNavigatingTo(INavigationParameters parameters)
        {

            if (parameters.ContainsKey("personagem"))
                Personagem = (Personagem)parameters["personagem"];
                
        }
    }
}
