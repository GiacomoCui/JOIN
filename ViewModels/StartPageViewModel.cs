namespace JOIN.ViewModels;

    public class StartPageViewModel : AppViewModelBase
    {
    private string nextToken =string.Empty;
    private string searchTerm = "";

    //da aggiungere terminato l'inserimento dell' API

    //[ObservableProperty]
    //private ObservableCollection<TournamentInstance> TournamentName;

        public StartPageViewModel() : base() 
        {
        Title = "ILJOIN";
        } 
    //aspetta che sia terminata una ricerca
    public override async void OnNavigatedTo(object parameters)
    {
        await Search();
    }

    private async Task Search()
    {
        SetDataLoadingIndicator(true);

        LoadingText = "Hold on a sec...";

        try
        {
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
        }
        finally
        {
            SetDataLoadingIndicator(false);
        }
    }
}

