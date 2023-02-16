
namespace JOIN.Views;

public partial class StartPage : ViewBase<StartPageViewModel>
{
	public StartPage()
	{
		InitializeComponent();
	}

    async void txtSearchQuery_Completed(object sender, EventArgs e)
	{
		ViewModel.SearchTournamentCommand.Execute(txtSearchQuery.Text);
	}
}