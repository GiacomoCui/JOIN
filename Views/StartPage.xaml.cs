
using JOIN.ViewModels.Login;
using JOIN.Views.Login;
using JOIN_App.ViewModels.ProfiloUtente;
using JOIN_App.Views.ProfiloUtente;

namespace JOIN.Views;

public partial class StartPage : ViewBase<StartPageViewModel>
{
	public StartPage()
	{
		InitializeComponent();
	}
    private async void Profilo(object sender, EventArgs e)
    {

        await Navigation.PushAsync(new PaginaProfiloUtente(new ProfiloUtenteViewModel(null)));

    }

    private async void Login(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new PaginaLogin());
    }
}