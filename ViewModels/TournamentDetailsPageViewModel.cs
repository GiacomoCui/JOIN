
using System.Net;

namespace JOIN.ViewModels;

public partial class TournamentDetailsPageViewModel : AppViewModelBase
{
    [ObservableProperty]
    private Attributes theTournament;

    public event EventHandler DownloadCompleted;

    public TournamentDetailsPageViewModel(IApiService appApiService) : base(appApiService)
    {
        Title = "TournamentPage";
    }

    public override async void OnNavigatedTo(object parameters)
    {
        var torunamentID = (Attributes)parameters;

        SetDataLoadingIndicator(true);

        LoadingText= "Hold on while we are loading tournament...";
        await Task.Delay(1000);
        TheTournament = new();

        try
        {
            TheTournament = torunamentID;

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
