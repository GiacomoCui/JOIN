using JOIN_App.ViewControls.Utenti;

namespace JOIN_App.ViewModels.ProfiloUtente;

public partial class ProfiloUtenteViewModel : ObservableObject
{
    [ObservableProperty]
    Utente user;

    public ProfiloUtenteViewModel(Utente user)
    {
        this.user = user;
        this.user.SetTornei(this.user);
        this.user.SetVittorie(this.user);
        this.user.GetBioDB(this.user);
    }
}
