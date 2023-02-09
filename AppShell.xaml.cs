using JOIN.Views;
namespace JOIN
{
    public partial class AppShell : Microsoft.Maui.Controls.Shell
    {
        public AppShell()
        {
            InitializeComponent();

            /*Routing.RegisterRoute(nameof(AddTournamentPage),
                typeof(AddTournamentPage));
            */
            Routing.RegisterRoute(nameof(TournamentPage),
                typeof(TournamentPage));

            Routing.RegisterRoute(nameof(RegistrationPage),
                typeof(RegistrationPage));
        }
    }
}