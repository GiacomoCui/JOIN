using Microsoft.Maui.Controls;

namespace JOIN.ViewControls;

public partial class TournamentCell
{
    public static readonly BindableProperty ParentContextProperty = BindableProperty.Create(
        "ParentContext",
        typeof(object),
        typeof(TournamentCell),
        null,
        propertyChanged:
        (bindableObject, oldValue, newValue) =>
        {
            if (newValue is not null && bindableObject is TournamentCell cell && newValue != oldValue)
            {
                cell.ParentContext = newValue;
            }
        }
    );

    public object ParentContext
    {
        get { return GetValue(ParentContextProperty); }
        set { SetValue(ParentContextProperty, value); }
    }

    public TournamentCell()
	{
		InitializeComponent();
	}
}