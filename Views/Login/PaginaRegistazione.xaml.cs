using JOIN.Control;
using NpgsqlTypes;
using System.Xml;

namespace JOIN.Views.Login;

public partial class PaginaRegistazione : ContentPage
{
	public PaginaRegistazione()
	{
		InitializeComponent();
	}

	private async void Salva(object sender, EventArgs e)
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

        /*Controllo omonimia*/
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


        /*Inserimento nuovo utente*/
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