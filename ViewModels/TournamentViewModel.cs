using JOIN.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace JOIN.ViewModels
{
    public class TournamentViewModel : ViewModelBase
    {
        private Tournament _tournament;
        public Tournament Tournament
        {
            get => _tournament;
            set
            {
                _tournament = value;
                OnPropertyChanged();
            }
        }


        public string Name => _tournament.Name;
        public string Game => _tournament.Game;
        public DateTime Date => _tournament.Date;
        private List<string> Prizes => _tournament.Prizes;
        public string ImageUrl => _tournament.ImageUrl;
        public ObservableCollection<Participant> Participants { get; }

        public TournamentViewModel(Tournament tournament)
        {
            _tournament = tournament;

            // Inizializza il comando di registrazione
            RegisterCommand = new Command(() =>
            {
                // Logica di registrazione
            });
        }


        // Proprietà per il comando di registrazione
        public ICommand RegisterCommand { get; set; }
    }
}




