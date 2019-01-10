using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using PrismHeroes.Models.MarvelHeroesCN.Models;
using PrismHeroes.Services;

namespace PrismHeroes.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public ObservableCollection<Personagem> Personagens { get; }

        private DelegateCommand<Personagem> _ExibirPersonagemCommand;
        public DelegateCommand<Personagem> ExibirPersonagemCommand => _ExibirPersonagemCommand ?? (_ExibirPersonagemCommand = new DelegateCommand<Personagem>(async (itemSelect) => await ExecuteExibirPersonagemCommand(itemSelect), (itemSelect) => !IsBusy));

        IMarvelApiService _MarvelApiService;

        protected MainViewModel(INavigationService navigationService,
                IPageDialogService pageDialogService,IMarvelApiService marvelApiService) : base(navigationService, pageDialogService)
        {
            Title = "Herois Marvel";

            Personagens = new ObservableCollection<Personagem>();
            _MarvelApiService = marvelApiService;

        }

 
        public override async void OnNavigatingTo(INavigationParameters parameters)
        {
            await LoadAsync();
        }

        public override async void OnNavigatedTo(INavigationParameters parameters)
        {
            var navigationMode = parameters.GetNavigationMode();
            if (navigationMode == NavigationMode.Back)
            {
                Console.Write("Voltei!");
                return;
            }
            else
            {
                Console.Write("Navegando para");
            }

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
