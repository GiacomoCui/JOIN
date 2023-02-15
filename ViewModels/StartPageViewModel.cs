
namespace JOIN.ViewModels;

public partial class StartPageViewModel : AppViewModelBase
    {
    private string nextPageToken = "1";

    //da usare qunado si implementa la ricerca di un determinato torneo
    private string searchTerm = string.Empty;

    [ObservableProperty]
    private ObservableCollection<Tournament> tournamentResponse;

    [ObservableProperty]
    private string welcomeMessage = string.Empty;

    [ObservableProperty]
    private bool isLoadingMore;

        public StartPageViewModel(IApiService appApiService) : base(appApiService) 
        {
        Title = "Home";

        //rendere dinamica questa parte del codice. Appena il DB sarà implementato, inserire la presa del nome nella funzione a riga 70
        WelcomeMessage= TakeUserName();
        }


    public override async void OnNavigatedTo(object parameters)
    {
        await Search();
    }

    private async Task Search()
    {
        SetDataLoadingIndicator(true);

        LoadingText = "Hold on a sec, searching for tournament...";

        TournamentResponse = new();

        try
        {
            //Chiamata all'API per trovare la prima pagina di tornei, composta da 25 elementi, senza ricerca
            await GetTournamentList();
           
            DataLoaded = true;
        }
        catch (InternetConnectionException)
        {
            IsErrorState = true;
            ErrorMessage = $"Slow or no internet connection" + Environment.NewLine + "Please check your internet connection and retry";
            ErrorImage = $"nointernet.png";
        }
        catch (Exception ex)
        {
            IsErrorState = true;
            ErrorMessage = $"Something went wrong. error code: {ex.Message}";
            ErrorImage = $"error.png";
        }
        finally
        {
            SetDataLoadingIndicator(false);
        }
    }

    private async Task GetTournamentList()
    {

        var tournamentSearchResult = await _appApiService.SearchTournaments(nextPageToken);

        if (tournamentSearchResult.Data != null)
        {
            nextPageToken= tournamentSearchResult.Links.Next;
        }
        else
        {
            nextPageToken = null;
        }

        TournamentResponse.AddRange(tournamentSearchResult.Data);
    }
    private string TakeUserName()
    {
        string username;
        username = "KiritoVegetable"; //inserire qui la funzione per prendere il nome dell'utente
        return $"Ben tornato, {username}";
    }


    //inserire qui il comando per aprire la pagina delle impostazioni
    [RelayCommand]
    private async void OpenSettingPage()
    {
        await PageService.DisplayAlert("Setting", "This feature is not yet implemented", "got it!");
    }

    [RelayCommand]
    private async Task LoadMoreTournament()
    {
        if(IsLoadingMore || string.IsNullOrEmpty(nextPageToken))
            return;

        IsLoadingMore = true;
        await Task.Delay(2000);
        await GetTournamentList();
        IsLoadingMore=false;
    }

    [RelayCommand]
    private async Task SearchTournament(string searchQuery)
    {
        nextPageToken = "1";
        searchTerm  = searchQuery.Trim();

        await Search();
    }

}

