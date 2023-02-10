
using JOIN_App.Views.ProfiloUtente;

namespace JOIN;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(PaginaProfiloUtente), typeof(PaginaProfiloUtente));
	}
}