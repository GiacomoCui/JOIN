using Dynamitey;

namespace JOIN.Views;

public partial class TournamentDetailsPage : ViewBase<TournamentDetailsPageViewModel>
{
	public TournamentDetailsPage(object initParam): base(initParam)
	{
		InitializeComponent();

		this.ViewModelInitialized += (s, e) =>
		{
			(this.BindingContext as TournamentDetailsPageViewModel).DownloadCompleted += TournamentDetailsPage_DownloadCompleted;
		};
	}

    protected override void OnDisappearing()
    {
        (this.BindingContext as TournamentDetailsPageViewModel).DownloadCompleted -= TournamentDetailsPage_DownloadCompleted;
    }

    private void TournamentDetailsPage_DownloadCompleted(object sender, EventArgs e)
    {

        if ((this.BindingContext as TournamentDetailsPageViewModel).IsErrorState)
            return;

        if (this.AnimationIsRunning("TransitionAnimation"))
            return;

        var parentAnimation = new Animation();

        parentAnimation.Add(0.0, 0.7, new Animation(v => HeaderView.Opacity = v, 0, 1, Easing.CubicIn));

        parentAnimation.Add(0.4, 0.7, new Animation(v => TournamentTitleStack.Opacity = v,0,1, Easing.CubicIn));

        parentAnimation.Add(0.5, 0.7, new Animation (v=> TournamentIcon.Opacity = v,0,1, Easing.CubicIn));

        parentAnimation.Commit(this, "TransitionAnimation", 16, Constants.LongDuration, null,
        (v,c) =>
        {
           //Action  to perform on completition (if any)
        });

    }
}