namespace JOIN.ViewControls.CommonControls;

public partial class LoadingIndicator : VerticalStackLayout
{
    public static readonly BindableProperty IsBusyProperty = BindableProperty.Create(
        "IsBusy",
        typeof(bool),
        typeof(LoadingIndicator),
        false,
        BindingMode.OneWay,
        null,
        SetIsBusy
        );

    public bool IsBusy
    {
        get => (bool)GetValue(IsBusyProperty);
        set => SetValue(IsBusyProperty, value);
    }

    public static void SetIsBusy(BindableObject bindable, object oldValue, object newValue)
    {
        LoadingIndicator control = bindable as LoadingIndicator;

        control.IsVisible = (bool)newValue;
        control.actIndicator.IsRunning= (bool)newValue; 
    }

    public static readonly BindableProperty LoadingTextProperty = BindableProperty.Create(
        "LoadingText",
        typeof(string),
        typeof(LoadingIndicator),
        false,
        BindingMode.OneWay,
        null,
        SetIsBusy
        );
    public string LoadingText
    {
        get => (string)GetValue(LoadingTextProperty);
        set => SetValue(LoadingTextProperty, value);
    }

    public static void SetLoadingText(BindableObject bindable, object oldValue, object newValue)
    {
        (bindable as LoadingIndicator).lblLoadingText.Text = (string)newValue;
    }

    public LoadingIndicator()
	{
		InitializeComponent();
	}
}