
using JOIN.Models;

namespace JOIN_App.ViewControls.Utenti;

public partial class Utente
{
    public string nome { get; set; }
    public int tornei { get; set; }
    public int vittorie { get; set; }
    public List<Tournament> t { get; set; }


    public Utente(string nome, int tornei, int vittorie)
    {
        this.nome = nome;
        this.tornei = tornei;
        this.vittorie = vittorie;
    }

    public Utente()
    {
    }
}
