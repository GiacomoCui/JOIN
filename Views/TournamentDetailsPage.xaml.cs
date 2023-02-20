namespace JOIN.Views;

public partial class TournamentDetailsPage : ViewBase<TournamentDetailsPageViewModel>
{
	public TournamentDetailsPage(object initParam): base(initParam)
	{
		InitializeComponent();

		ViewModelInitialized += (s, e) =>
		{
			(BindingContext as TournamentDetailsPageViewModel).DownloadCompleted += TournamentDetailsPage_DownloadCompleted;
		};
	}

    protected override void OnDisappearing()
    {
        (BindingContext as TournamentDetailsPageViewModel).DownloadCompleted -= TournamentDetailsPage_DownloadCompleted;
    }

    private void TournamentDetailsPage_DownloadCompleted(object sender, EventArgs e)
    {

        if ((BindingContext as TournamentDetailsPageViewModel).IsErrorState)
            return;

        if (this.AnimationIsRunning("TransitionAnimation"))
            return;

        var parentAnimation = new Animation
        {
            { 0.0, 0.7, new Animation(v => HeaderView.Opacity = v, 0, 1, Easing.CubicIn) },

            { 0.4, 0.7, new Animation(v => TournamentTitleStack.Opacity = v, 0, 1, Easing.CubicIn) },

            { 0.5, 0.7, new Animation(v => TournamentIcon.Opacity = v, 0, 1, Easing.CubicIn) },

            { 0.4, 0.7, new Animation(v => btnIscrizione.Opacity = v, 0, 1, Easing.CubicIn) },

            { 0.5, 0.7, new Animation(v => descriptionTournament.Opacity = v, 0, 1, Easing.CubicIn) }
        };


        parentAnimation.Commit(this, "TransitionAnimation", 16, Constants.LongDuration, null,
        (v,c) =>
        {
           //Action  to perform on completition (if any)
        });

    }

    async void btnTournamnet_Clicked(object sender, EventArgs e)
    {
        await IscrizioneButtonSheet.OpenBottomSheet();
    }

    //Da inserire la modifica del profilo

    private void Accetta_Clicked(object sender, EventArgs e)
    {

    }

    private async void Annulla_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}