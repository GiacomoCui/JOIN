using JOIN.Control;
using JOIN.ViewModels.Login;
using JOIN_App.ViewControls.Utenti;
using NpgsqlTypes;

namespace JOIN.Views.Login;

public partial class PaginaLogin : ContentPage
{
	public PaginaLogin()
	{

        InitializeComponent();
        NavigationPage.SetHasNavigationBar(this, false);
    }

	private async void Registrati(object sender, EventArgs e) {
		await Navigation.PushAsync(new PaginaRegistazione());
	}

	private async void Accedi(object sender, EventArgs e)
	{
        Console.WriteLine("Bene (Accedi)\n");
        Connessione con = new Connessione();
        NpgsqlCommand cmd = new NpgsqlCommand();

        string nome = txtNome.Text;
        string password = txtPassword.Text;

        con.Open(); //Apertura
        cmd.Connection = con.GetCon();


        /*Controlli stanadard*/
        if (string.IsNullOrEmpty(nome))
        {
            await DisplayAlert("Username non valido", "Riempire il campo username", "OK");
            return;
        }

        if (string.IsNullOrEmpty(password))
        {
            await DisplayAlert("Password non valida", "Riempire il campo password", "OK");
            return;
        }
                
        /*Controllo esistenza utente*/
        string query = "SELECT COUNT(*) FROM Utente WHERE nome = @nome AND pas = @password";

        cmd.CommandText = query;
        cmd.Parameters.AddWithValue("@nome", nome);
        cmd.Parameters.AddWithValue("@password", password);
        int count = Convert.ToInt32(cmd.ExecuteScalar());

        if (count == 0)
        {
            // Utente non esistente
            await DisplayAlert("Username o Password Errati", "Riprova", "Ok");
            return;
        }
        else {
            Utente user = new Utente(nome);
            await Navigation.PushAsync(new StartPage(user));
        }

        con.Close(); //Chiusura

        txtNome.Text = "";
        txtPassword.Text = "";
    } 
}