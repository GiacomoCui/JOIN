using JOIN_App.ViewControls.Utenti;
using JOIN_App.ViewModels.ProfiloUtente;

namespace JOIN.Views.ProfiloUtente;

public partial class PaginaProfiloModificabile : ContentPage
{
	public PaginaProfiloModificabile(PaginaProfiloModificabileViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}