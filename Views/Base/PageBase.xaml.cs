
namespace JOIN.Views.Base;

public partial class PageBase : ContentPage
{
	public IList<Microsoft.Maui.IView> PageContent => PageContentGrid.Children;
    //public IList<Microsoft.Maui.IView> PageIcons => PageIconsGrid.Children;

	protected bool IsBackButtonEnabled
	{
		set => NavigateBackButton.IsEnabled = value;	
	}

	#region Bindable properties
	public static readonly BindableProperty PageTitleProperty = BindableProperty.Create(
		nameof(PageTitle),
		typeof(string),
		typeof(PageBase),
		string.Empty,
		defaultBindingMode:
		BindingMode.OneWay,
		propertyChanged: OnPageTitleChanged);

	public string PageTitle
	{
		get => (string)GetValue(PageTitleProperty);
		set => SetValue(PageTitleProperty, value);
	}

	private static void OnPageTitleChanged(BindableObject bindable, object oldValue, object newValue)
	{
		if(bindable != null && bindable is PageBase basePage)
		{
			basePage.TitleLabel.Text = (string)newValue;
			basePage.TitleLabel.IsVisible = true;
		}
	}

    public static readonly BindableProperty PageModeProperty = BindableProperty.Create(
        nameof(PageMode),
        typeof(PageMode),
        typeof(PageMode),
		PageMode.None,
        propertyChanged: OnPageModePropertyChanged);

    public PageMode PageMode
    {
        get => (PageMode)GetValue(PageModeProperty);
        set => SetValue(PageModeProperty, value);
    }

    private static void OnPageModePropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (bindable != null && bindable is PageBase basePage)
        {
			basePage.SetPageMode((PageMode)newValue);
        }
    }

	private void SetPageMode(PageMode pageMode)
	{
		switch(pageMode)
		{
			case PageMode.Menu:
				HamburgherButton.IsVisible= true;
				NavigateBackButton.IsVisible= false;
				CloseButton.IsVisible= false;	
				break;
            case PageMode.Navigate:
                HamburgherButton.IsVisible = false;
                NavigateBackButton.IsVisible = true;
                CloseButton.IsVisible = false;
                break;
            case PageMode.Modal:
                HamburgherButton.IsVisible = false;
                NavigateBackButton.IsVisible = false;
                CloseButton.IsVisible = true;
				break;
			default:
                HamburgherButton.IsVisible = false;
                NavigateBackButton.IsVisible = false;
                CloseButton.IsVisible = false;
                break;
                
        }
	}

	public static readonly BindableProperty ContentDisplayModeProperty = BindableProperty.Create(
		nameof(ContentDisplayMode),
		typeof(ContentDisplayMode),
		typeof(PageBase),
		ContentDisplayMode.NoNavigationBar,
		propertyChanged: OnContentDisplayModePropertyChanged);

	public ContentDisplayMode ContentDisplayMode
	{
		get => (ContentDisplayMode)GetValue(ContentDisplayModeProperty);
		set => SetValue(ContentDisplayModeProperty, value);
	}

	private static void OnContentDisplayModePropertyChanged (BindableObject bindable, object oldValue, object newValue)
	{
		if(bindable != null && bindable is PageBase basePage)
		{
			basePage.SetContentDisplayMode((ContentDisplayMode)newValue);
		}
	}

	private void SetContentDisplayMode(ContentDisplayMode contentDisplayMode)
	{
		switch(contentDisplayMode) 
		{
			case ContentDisplayMode.NoNavigationBar:
				Grid.SetRow(PageContentGrid, 0);
				Grid.SetRowSpan(PageContentGrid, 3);
				break;
			case ContentDisplayMode.NavigationBar:
                Grid.SetRow(PageContentGrid, 2);
                Grid.SetRowSpan(PageContentGrid, 1);
				break;
				default: 
				break;	
        }
	}

    #endregion



    public PageBase()
	{
		InitializeComponent();

		NavigationPage.SetHasNavigationBar(this, false);
		SetPageMode(PageMode.None);
		SetContentDisplayMode(ContentDisplayMode.NoNavigationBar);
	}
}