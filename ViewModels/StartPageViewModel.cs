



using Maui.App.Framework.Extensions;

namespace JOIN.ViewModels;

public partial class StartPageViewModel : AppViewModelBase
    {
    private string nextPageToken = string.Empty;
    private string searchTerm = "Mario";

    [ObservableProperty]
    private ObservableCollection<TournamentResponse> tournamentResponse;

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
            //Search for tournament
            await GetTournamentList();

            //time for execute the API service
            await Task.Delay(3000);
            DataLoaded = true;
        }
        catch (InternetConnectionException)
        {
            IsErrorState = true;
            ErrorMessage = $"Slow or no internet connection" + Environment.NewLine + "Please check your internet connection and retry";
            ErrorImage = $"nointernet.png";
        }
        catch (Exception)
        {
            IsErrorState = true;
            ErrorImage = $"Something went wrong. If the problem persist, please contact support";
            ErrorImage = $"error.png";
        }
        finally
        {
            SetDataLoadingIndicator(false);
        }
    }

    private async Task GetTournamentList()
    {
        var TournamentSearchResult = await _appApiService.SearchTournament(searchTerm, nextPageToken);

        nextPageToken = TournamentSearchResult.Links.Next;

        //verificare perché rompe questo codice demmerda
        TournamentResponse.AddRange(TournamentSearchResult.Tournaments);
    }

    [RelayCommand]
    private async void OpenSettingPage()
    {
        await PageService.DisplayAlert("Setting", "This feature is not yet implemented", "got it!");
    }
}

