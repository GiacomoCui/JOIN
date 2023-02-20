
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
        NavigationPage.SetHasNavigationBar(this, false);
        BindingContext = vm;
        this.vm = vm;   
    }

    private async void ModificaProfilo(object sender, EventArgs e)
    {
        await ModificaButtonSheet.OpenBottomSheet();
    }

    private async void Modifica_Clicked(object sender, EventArgs e)
    {
        
    }

    private async void Annulla_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}