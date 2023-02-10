using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JOIN.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        // Questo method viene chiamato quando la pagina viene visualizzata
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            // Questo codice viene utilizzato per verificare se l'utente è già loggato.
            var loggedin = true;

            // Se l'utente è già loggato, viene reindirizzato alla StartPage
            if (loggedin)
                await Shell.Current.GoToAsync($"//{nameof(StartPage)}");

        }

        // Questo evento viene chiamato quando viene fatto clic sul pulsante "Login"
        private async void Button_Clicked(object sender, EventArgs e)
        {
            // Reindirizzamento alla StartPage
            await Shell.Current.GoToAsync($"//{nameof(StartPage)}");
        }

        // Questo evento viene chiamato quando viene fatto clic sul Label "Register"
        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            // Reindirizzamento alla RegistrationPage
            await Shell.Current.GoToAsync($"{nameof(RegistrationPage)}");
        }
    }
}
