using System;
namespace JOIN.ViewModels
{
    public class AppearanceViewModel : AppViewModelBase
    {
        // Variabile booleana che indica se la modalità scura è abilitata
        private bool isDarkModeEnabled;
        public bool IsDarkModeEnabled
        {
            get => isDarkModeEnabled;
            set
            {
                // Se non viene modificato il valore, non fare nulla
                if (isDarkModeEnabled == value) return;
                isDarkModeEnabled = value;
                // Notifica l'aggiornamento della proprietà
                OnPropertyChanged();
                // Cambia il tema dell'app
                ChangeTheme();
            }
        }

        // Method che restituisce un'istanza di Switch con IsToggled impostato su IsDarkModeEnabled
        public Switch SwitchControl => new Switch
        {
            IsToggled = IsDarkModeEnabled
        };

        // Method che cambia il tema dell'app in base alla modalità scura
        private void ChangeTheme()
        {
            if (IsDarkModeEnabled)
            {
                // Se la modalità scura è abilitata, imposta i colori di sfondo e testo
                Application.Current.Resources["JOIN.BackgroundColor"] = Color.FromArgb("#333333");
                Application.Current.Resources["JOIN.TextColor"] = Color.FromArgb("#FFFFFF");
            }
            else
            {
                // Se la modalità scura non è abilitata, imposta i colori di sfondo e testo di default
                Application.Current.Resources["JOIN.BackgroundColor"] = Color.FromArgb("#FFFFFF");
                Application.Current.Resources["JOIN.TextColor"] = Color.FromArgb("#333333");
            }
        }
    }
}
