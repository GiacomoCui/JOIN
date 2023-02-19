namespace JOIN.ViewModels;

public partial class StartPageViewModel : AppViewModelBase
    {
    private string nextPageToken = string.Empty;

    [ObservableProperty]
    private ObservableCollection<Tournament> tournamentResponseVariable;

    [ObservableProperty]
    private string welcomeMessage = string.Empty;

    [ObservableProperty]
    private bool isLoadingMore;

        public StartPageViewModel(IApiService appApiService) : base(appApiService) 
        {
        Title = "Home";
        //rendere dinamica questa parte del codice. Appena il DB sarà implementato, inserire la presa del nome nella funzione a riga 70
        WelcomeMessage= TakeUserName();

        nextPageToken= "1";
        }


    public override async void OnNavigatedTo(object parameters)
    {
        await Search();
    }

    private async Task Search()
    {
        SetDataLoadingIndicator(true);

        LoadingText = "Hold on a sec, searching for tournament...";

        TournamentResponseVariable = new();

        try
        {
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
        //qua se si riesce a trasformare il token in intero, aggiungere 1, e poi farlo tornare stringa sarebbe meglio. Per ora si tiene questo

        if (tournamentSearchResult.Data != null)
        {
            if(nextPageToken == "1")
            {
                nextPageToken= "2";
            }else if(nextPageToken == "2")
            {
                nextPageToken= "3";
            }
            else if (nextPageToken == "3")
            {
                nextPageToken = "4";
            }
            else
            {
                nextPageToken = null;
            }
        }
        else
        {
            nextPageToken = null;
        }

        tournamentSearchResult.Data.ForEach(x => { x.Attributes.RelationshipsCopy = x.Relationships; });

        tournamentSearchResult.Data.ForEach(x => { if (x.Attributes.SignupCap is null) x.Attributes.SignupCap = "Infinito"; });

        ImpostaOrganizzatore(tournamentSearchResult);

            TournamentResponseVariable.AddRange(tournamentSearchResult.Data);
        
    }

    private static void ImpostaOrganizzatore(TournamentResponse arg)
    {
        arg.Data.ForEach(x => { 
            arg.Included.ForEach(y =>
            { 
                if(y.Type == "user")
                {
                    if(y.Id == x.Relationships.Organizer.Data.Id)
                    {
                        x.Attributes.OrganizerUsername = y.Attributes.OrganizerUsername;
                        x.Attributes.OrganizerImageUrl = y.Attributes.OrganizerImageUrl;
                    }
                }             
            });
            
        });
    }


    private static string TakeUserName()
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
    private async Task SearchTournament(string searchQuery)
    {
        await Search();
    }


    [RelayCommand]
    private async Task LoadMoreTournament()
    {
        if (IsLoadingMore || string.IsNullOrEmpty(nextPageToken))
            return;

        IsLoadingMore = true;
        await GetTournamentList();
        IsLoadingMore = false;
    }

    [RelayCommand]
    private async Task NavigateToVideoDetailsPage(Attributes videoId) 
    {
        await NavigationService.PushAsync(new TournamentDetailsPage(videoId));
    }
}

