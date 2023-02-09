
namespace JOIN;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(StartPage), typeof(StartPage));
	}
}