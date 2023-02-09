using JOIN.Views.ProfiloUtente;
using JOIN_App.ViewModels.ProfiloUtente;
using JOIN_App.Views.ProfiloUtente;

namespace JOIN.ViewModels;

    public partial class StartPageViewModel : AppViewModelBase
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

    public override async void OnNavigatedTo(object parameters)
    {
        await Search();
    }

    [RelayCommand]
    async Task ModificaProfilo()
    {
        await Shell.Current.GoToAsync($"{nameof(PaginaProfiloUtente)}");
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

