
using JOIN.Control;
using JOIN.Models;

namespace JOIN_App.ViewControls.Utenti;

public partial class Utente
{
    public string nome { get; set; }
    public int tornei { get; set; }
    public int vittorie { get; set; }
    public string bio { get; set; }

    public List<Tournament> t { get; set; }


    public Utente(string nome)
    {
        this.nome = nome;
    }

    public void SetTornei(Utente user)
    {
        Connessione con = new Connessione();
        NpgsqlCommand cmd = new NpgsqlCommand();

        con.Open();
        cmd.Connection = con.GetCon();

        string query = "SELECT COUNT(torneo) " +
                       "FROM Utente u JOIN Partecipazione on u.codice = utente " +
                       "WHERE nome = @nome " +
                       "GROUP BY nome";
        cmd.CommandText = query;
        cmd.Parameters.AddWithValue("@nome", user.nome);
        int num_tornei = Convert.ToInt32(cmd.ExecuteScalar());

        user.tornei = num_tornei;

        con.Close();
    }

    public void SetVittorie(Utente user)
    {
        Connessione con = new Connessione();
        NpgsqlCommand cmd = new NpgsqlCommand();

        con.Open();
        cmd.Connection = con.GetCon();

        string query = "SELECT COUNT(posizione) " +
                       "FROM Utente u JOIN Partecipazione on u.codice = utente " +
                       "WHERE nome = @nome AND posizione = 1 " +
                       "GROUP BY nome";
        cmd.CommandText = query;
        cmd.Parameters.AddWithValue("@nome", user.nome);
        int num_vittorie = Convert.ToInt32(cmd.ExecuteScalar());

        user.vittorie = num_vittorie;

        con.Close();
    }
}
