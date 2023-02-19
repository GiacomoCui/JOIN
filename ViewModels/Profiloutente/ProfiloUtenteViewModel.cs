
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
      if (user == null)
        user = new Utente("UserX", 0, 0);
        
        this.user = user;
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
    
    /*
    [RelayCommand]
    async Task Add()
    {
        //Se non si inserisce nienete allora non alterare lo stato attuale della collezione
        if (string.IsNullOrWhiteSpace(Text))
            return;

        //Verifica se il dispositivo è connesso
        if (connectivity.NetworkAccess != NetworkAccess.Internet)
        {
            await Shell.Current.DisplayAlert("Errore:No Internet", "Connesione Internet Assente", "OK"); //Messaggio d'errore
            return;
        }

        //Elemento.Add(text);  //Aggiunge un nuovo elemento
        Text = string.Empty; //Ripulisce la stringa
    }
    */

}