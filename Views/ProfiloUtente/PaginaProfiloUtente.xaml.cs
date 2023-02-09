
using JOIN.Views.ProfiloUtente;
using JOIN_App.ViewControls.Utenti;
using JOIN_App.ViewModels.ProfiloUtente;

namespace JOIN_App.Views.ProfiloUtente;

[QueryProperty(nameof(Utente), nameof(Utente))]
public partial class PaginaProfiloUtente : ContentPage
{
    public PaginaProfiloUtente(ProfiloUtenteViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }   
}