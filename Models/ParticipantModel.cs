
namespace JOIN.Models;

public class Participant
{
    public class ParticipantModel
    {

        /*
         * Questa classe ha sei proprietà: Name, Team, Country, Birthdate, DiscordContact e TwitterContact. 
         * Queste proprietà rappresentano il nome, il team, il paese di provenienza, la data di nascita, 
         * il contatto Discord e il contatto Twitter del partecipante al torneo.
        */

        public string Name { get; set; }
        public string Team { get; set; }
        public string Country { get; set; }
        public DateTime Birthdate { get; set; }
        public string DiscordContact { get; set; }
        public string TwitterContact { get; set; }

        /*
         * 
         * Questo costruttore accetta sei argomenti: name, team, country, birthdate, discordContact e twitterContact. 
         * Questi argomenti vengono assegnati alle proprietà della classe quando un nuovo oggetto Participant viene creato. 
         * Questo rende più semplice creare nuovi oggetti Participant passando i valori appropriati per ogni proprietà.
        */

        public ParticipantModel(string name, string team, string country, DateTime birthdate, string discordContact, string twitterContact)
        {
            Name = name;
            Team = team;
            Country = country;
            Birthdate = birthdate;
            DiscordContact = discordContact;
            TwitterContact = twitterContact;
        }
    }
}
	

