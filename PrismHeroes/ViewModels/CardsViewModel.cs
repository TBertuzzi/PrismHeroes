using System;
using System.Collections.ObjectModel;
using System.Linq;
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
            Title = "Cartões Marvel";

            Personagens = new ObservableCollection<Personagem>();
            _MarvelApiService = marvelApiService;

            //IsActiveChanged += HandleIsActiveTrue;
            //IsActiveChanged += HandleIsActiveFalse;

        }

        //private async void HandleIsActiveTrue(object sender, EventArgs args)
        //{
        //    if (IsActive == false) return;

        //        await LoadAsync();
        //}

        //private void HandleIsActiveFalse(object sender, EventArgs args)
        //{
        //    if (IsActive == true) return;
        //}

        //public override void Destroy()
        //{
        //    IsActiveChanged -= HandleIsActiveTrue;
        //    IsActiveChanged -= HandleIsActiveFalse;
        //}

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
                Personagens.Clear();

                IsBusy = true;

                var personagensMarvel = await _MarvelApiService.GetPersonagensAsync();


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
