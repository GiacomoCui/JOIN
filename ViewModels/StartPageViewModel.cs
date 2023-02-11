
namespace JOIN.ViewModels;

public partial class StartPageViewModel : AppViewModelBase
    {
    private string nextPageToken = string.Empty;

    //da usare qunado si implementa la ricerca di un determinato torneo
    //private string searchTerm = "Mario";

    [ObservableProperty]
    private ObservableCollection<Tournament> tournamentResponse;

        public StartPageViewModel(IApiService appApiService) : base(appApiService) 
        {
        Title = "ILJOIN";
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
            //La query genera un errore
            await Task.Delay(3000);
            await GetTournamentList();

            //time for execute the API service
           
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

        nextPageToken = tournamentSearchResult.Links.Next;

        TournamentResponse.AddRange(tournamentSearchResult.Data);
    }

    [RelayCommand]
    private async void OpenSettingPage()
    {
        await PageService.DisplayAlert("Setting", "This feature is not yet implemented", "got it!");
    }
}

