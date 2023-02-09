
using JOIN.Views.ProfiloUtente;
using JOIN_App.ViewControls.Utenti;
using JOIN_App.ViewModels.ProfiloUtente;
using JOIN_App.Views.ProfiloUtente;

namespace JOIN.Views;

public partial class StartPage : ViewBase<StartPageViewModel>
{
	public StartPage()
	{
		InitializeComponent();

    }

    private void Profilo(object sender, EventArgs e)
    {
        Navigation.PushAsync(new PaginaProfiloUtente(new ProfiloUtenteViewModel()));
    }
}