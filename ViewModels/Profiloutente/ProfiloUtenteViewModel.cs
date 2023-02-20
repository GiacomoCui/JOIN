
using JOIN.Models;
using JOIN.Views.ProfiloUtente;
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
    }

    public Utente GetUtente()
    {
        return user;
    }

    /*Per andare nella pagina delle modifiche*/
    [RelayCommand]
    async Task ModificaProfilo()
    {
        await Shell.Current.GoToAsync($"{nameof(PaginaProfiloModificabile)}");
    }
}