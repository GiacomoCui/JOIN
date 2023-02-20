
using JOIN.Control;
using JOIN.Models;

namespace JOIN_App.ViewControls.Utenti;

public partial class Utente
{
    public string nome { get; set; }
    public int tornei { get; set; }
    public int vittorie { get; set; }

   // public List<Tournament> t { get; set; }


    public Utente(string nome)
    {
        this.nome = nome;
    }

    public void SetTornei(Utente user)
    {
        Connessione con = new Connessione();
        NpgsqlCommand cmd = new NpgsqlCommand();
    }
}
