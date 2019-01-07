using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Prism.Navigation;
using Prism.Services;
using PrismHeroes.Models.MarvelHeroesCN.Models;
using PrismHeroes.Services;

namespace PrismHeroes.ViewModels
{
    public class CardsViewModel : ViewModelBase
    {
        public ObservableCollection<Personagem> Personagens { get; }

        IMarvelApiService _MarvelApiService;

        protected CardsViewModel(INavigationService navigationService,
                IPageDialogService pageDialogService, IMarvelApiService marvelApiService) : base(navigationService, pageDialogService)
        {
            Title = "Herois Marvel";

            Personagens = new ObservableCollection<Personagem>();
            _MarvelApiService = marvelApiService;

        }

        public override async void OnNavigatingTo(INavigationParameters parameters)
        {

            await LoadAsync();
        }

        private async Task ExecuteExibirPersonagemCommand(Personagem personagem)
        {
            var navigationParams = new NavigationParameters
            {
                {"personagem", personagem}
            };


            await NavigationService.NavigateAsync("DetalhesPage", navigationParams);
        }

        private async Task LoadAsync()
        {
            try
            {
                IsBusy = true;

                var personagensMarvel = await _MarvelApiService.GetPersonagensAsync();

                Personagens.Clear();

                foreach (var personagem in personagensMarvel)
                {
                    Personagens.Add(personagem);
                }

            }
            catch (Exception ex)
            {
                await PageDialogService.DisplayAlertAsync("Erro", "Erro ao Carregar personagens:" + ex.Message, "OK");
            }
            finally
            {

                IsBusy = false;
            }
        }

    }
}
