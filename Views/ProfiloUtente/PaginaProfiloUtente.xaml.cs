
using JOIN.Views.ProfiloUtente;
using JOIN_App.ViewControls.Utenti;
using JOIN_App.ViewModels.ProfiloUtente;

namespace JOIN_App.Views.ProfiloUtente;

public partial class PaginaProfiloUtente : ContentPage
{
    public ProfiloUtenteViewModel vm;

    public PaginaProfiloUtente(ProfiloUtenteViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
        this.vm = vm;   
    }

    private async void ModificaProfilo(object sender, EventArgs e)
    {

        await Navigation.PushAsync(new PaginaProfiloModificabile(new PaginaProfiloModificabileViewModel(vm.GetUtente())));

    }
}