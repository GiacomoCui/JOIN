
namespace JOIN.Views
{
    public partial class AppearancePage : ContentPage
    {
        public AppearancePage()
        {
            InitializeComponent();

            // Imposta il BindingContext su un'istanza della classe AppearanceViewModel
            BindingContext = new AppearanceViewModel();
        }

        // Questo method viene chiamato quando il Switch viene toccato
        private void OnDarkModeSwitchToggled(object sender, ToggledEventArgs e)
        {
            // Ottiene l'istanza del ViewModel
            var viewModel = (AppearanceViewModel)BindingContext;

            // Imposta il valore di IsDarkModeEnabled sul valore contrario di quello corrente
            viewModel.IsDarkModeEnabled = !viewModel.IsDarkModeEnabled;
        }
    }
}
