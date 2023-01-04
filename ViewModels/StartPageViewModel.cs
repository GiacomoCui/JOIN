namespace JOIN.ViewModels;

    public class StartPageViewModel : AppViewModelBase
    {
        public StartPageViewModel() : base() 
        {
        this.Title = "ILJOIN";
        } 

    public override async void OnNavigatedTo(object parameters)
    {
        SetDataLoadingIndicator(true);

        LoadingText = "hold on a sec...";

        try
        {
            await Task.Delay(3000);
        }
        catch
        {

        }
        finally 
        {
            SetDataLoadingIndicator(false);
        }
    }
    }

