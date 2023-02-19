using Dynamitey.DynamicObjects;

namespace JOIN.Control;
public class Connessione
{
    private string con = "Server=localhost;Port=5432;User Id=postgres;Password=postgres;Database=mc;Timezone=Europe/Rome";
    private NpgsqlConnection connessione;

    public Connessione()
    {
        connessione = new NpgsqlConnection(con);
    }

    public void Open()
    {
        connessione.Open();
    }

    public void Close()
    {
        connessione.Close();
    }

    public NpgsqlConnection GetCon()
    {
        return connessione;
    }
}

