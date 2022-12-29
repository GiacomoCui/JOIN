namespace JOIN.ViewControls.CommonControls;

public partial class ErrorIndicator : VerticalStackLayout
{
	public static readonly BindableProperty IsErrorProperty = BindableProperty.Create(
		"IsError",
		typeof(bool),
		typeof(ErrorIndicator),
		false,
		BindingMode.OneWay,
		null,
		SetIsError
		);

	public bool IsError { 
		get => (bool)GetValue(IsErrorProperty);
		set => SetValue(IsErrorProperty, value);
	}

	public static void SetIsError(BindableObject bindable, object oldValue, object newValue) => 
		(bindable as ErrorIndicator).IsVisible = (bool)newValue;

	public static readonly BindableProperty ErrorTextProperty = BindableProperty.Create(
		"ErrorText",
		typeof(string),
		typeof(ErrorIndicator),
		string.Empty,
		BindingMode.OneWay,
		null,
		SetErrorText
		);

	public string ErrorText 
	{
		get => (string)GetValue(ErrorTextProperty);
		set => SetValue(ErrorTextProperty, value);
	}

    public static void SetErrorText(BindableObject bindable, object oldValue, object newValue) =>
    (bindable as ErrorIndicator).lblErrorText.Text = (string)newValue;

    public static readonly BindableProperty ErrorImageProperty = BindableProperty.Create(
        "ErrorImage",
        typeof(string),
        typeof(ErrorIndicator),
        string.Empty,
        BindingMode.OneWay,
        null,
        SetErrorImage
        );

    public string ErrorImage
    {
        get => (string)GetValue(ErrorTextProperty);
        set => SetValue(ErrorTextProperty, value);
    }

    public static void SetErrorImage(BindableObject bindable, object oldValue, object newValue) =>
    (bindable as ErrorIndicator).imgError.Text= (string)newValue;

    public ErrorIndicator()
	{
		InitializeComponent();
	}
}