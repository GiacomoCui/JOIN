
using JOIN.ViewModels;
using JOIN.ViewModels.Login;
using JOIN.Views.Login;
using JOIN_App.ViewControls.Utenti;
using JOIN_App.ViewModels.ProfiloUtente;
using JOIN_App.Views.ProfiloUtente;

namespace JOIN.Views;

public partial class StartPage : ViewBase<StartPageViewModel>
{
    Utente user;
    public StartPage(Utente user)
	{
		InitializeComponent();
        this.user = user;
    }
    private async void Profilo(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new PaginaProfiloUtente(new ProfiloUtenteViewModel(this.user)));
    }
}