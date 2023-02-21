using JOIN.Control;
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

        else
        {
            Utente user = new Utente(nome);
            await Navigation.PushAsync(new StartPage(user));
        }

        con.Close(); //Chiusura

        txtNome.Text = "";
        txtPassword.Text = "";
    }

    private async void Salva(object sender, EventArgs e)
    {
        Connessione con = new Connessione();
        NpgsqlCommand cmd = new NpgsqlCommand();

        string nome = txtNome.Text;
        string password = txtPassword.Text;

        con.Open(); //Apertura
        cmd.Connection = con.GetCon();


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

        if (nome.Length > 20)
        {
            await DisplayAlert("Username non valido", "Username troppo lungo", "OK");
            return;
        }


        if (password.Length > 20)
        {
            await DisplayAlert("Password non valida", "Password troppo lunga", "OK");
            return;
        }

        string query = "SELECT COUNT(*) FROM Utente WHERE nome = @nome";

        cmd.CommandText = query;
        cmd.Parameters.AddWithValue("@nome", nome);
        int count = Convert.ToInt32(cmd.ExecuteScalar());

        if (count > 0)
        {
            // La tupla con lo stesso nome esiste già
            await DisplayAlert("Errore", "Username inserito esiste già", "Ok");
            return;
        }


        cmd.CommandText = "INSERT INTO Utente (nome, pas) VALUES (@nome, @password)";
        cmd.Parameters.AddWithValue("@nome", NpgsqlDbType.Varchar, 20).Value = txtNome.Text;
        cmd.Parameters.AddWithValue("@password", NpgsqlDbType.Varchar, 20).Value = txtPassword.Text;
        cmd.Prepare();
        cmd.ExecuteNonQuery();

        con.Close(); //Chiusura

        await DisplayAlert("REGISTRAZIONE COMPLETATA", "Benvenuto nel club dei registarti", "Daje");

        txtNome.Text = "";
        txtPassword.Text = "";
    }
}