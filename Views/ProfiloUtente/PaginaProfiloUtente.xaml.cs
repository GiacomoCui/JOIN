
using JOIN.Control;
using JOIN_App.ViewControls.Utenti;
using JOIN_App.ViewModels.ProfiloUtente;
using NpgsqlTypes;

namespace JOIN_App.Views.ProfiloUtente;

public partial class PaginaProfiloUtente : ContentPage
{
    public ProfiloUtenteViewModel vm;

    public Utente user;
    public PaginaProfiloUtente(Utente user, ProfiloUtenteViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
        this.vm = vm;   
        this.user = user;
    }

    private async void ModificaProfilo(object sender, EventArgs e)
    {
        await ModificaButtonSheet.OpenBottomSheet();
    }

    private async void Modifica_Clicked(object sender, EventArgs e)
    {
        Connessione con = new Connessione();
        NpgsqlCommand cmd = new NpgsqlCommand();

        string nome = txtNome.Text;
        string bio = txtBio.Text;

        con.Open(); //Apertura
        cmd.Connection = con.GetCon();


        /*Controlli stanadard*/
        if (string.IsNullOrEmpty(nome))
        {
            await DisplayAlert("Username non valido", "Riempire il campo username", "OK");
            return;
        }

        if (nome.Length > 20)
        {
            await DisplayAlert("Username non valido", "Username troppo lungo", "OK");
            return;
        }


        if (bio.Length > 100)
        {
            await DisplayAlert("Bio non valida", "Bio troppo lunga", "OK");
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


        /*Modifica info utente*/
        cmd.CommandText = "UPDATE Utente " +
                "SET nome = @nome, bio = @bio " +
                "WHERE nome = @vecchio_nome";

        cmd.Parameters.AddWithValue("@nome", NpgsqlDbType.Varchar, 20).Value = nome;
        cmd.Parameters.AddWithValue("@bio", NpgsqlDbType.Varchar, 100).Value = bio;
        cmd.Parameters.AddWithValue("@vecchio_nome", NpgsqlDbType.Varchar, 20).Value = user.nome;
        cmd.Prepare();
        cmd.ExecuteNonQuery();

        user.SetNome(nome);
        user.SetBio(bio);

        con.Close(); //Chiusura

        await DisplayAlert("MODIFICA EFFETTUATA", "", "OK");
        

        txtNome.Text = "";
        txtBio.Text = "";

    }

    private async void Annulla_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}