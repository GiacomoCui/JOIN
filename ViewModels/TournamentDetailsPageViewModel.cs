
using System.Net;

namespace JOIN.ViewModels;

public partial class TournamentDetailsPageViewModel : AppViewModelBase
{
    [ObservableProperty]
    private Tournament theTournament;

    public event EventHandler DownloadCompleted;

    public TournamentDetailsPageViewModel(IApiService appApiService) : base(appApiService)
    {
        Title = "TournamentPage";
    }

    public override async void OnNavigatedTo(object parameters)
    {
        var torunamentID = (string)parameters;

        SetDataLoadingIndicator(true);

        LoadingText= "Hold on while we are loading tournament...";

        TheTournament = new();

        try
        {
            TheTournament = await _appApiService.SearchSingleTournament(torunamentID);

            DataLoaded = true;

            DownloadCompleted?.Invoke(this, new EventArgs());
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
}
