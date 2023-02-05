using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace JOIN
{
    public class Tournament : INotifyPropertyChanged
    {
        // Variabili private che rappresentano gli attributi del torneo
        private string _name;
        private DateTime _date;
        private string _game;
        private List<Models.Participant> _participants;
        private List<string> _prizes;

        // Proprietà pubbliche che espongono le variabili private
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }
        public DateTime Date
        {
            get => _date;
            set
            {
                _date = value;
                OnPropertyChanged();
            }
        }
        public string Game
        {
            get => _game;
            set
            {
                _game = value;
                OnPropertyChanged();
            }
        }
        public List<Models.Participant> Participants
        {
            get => _participants;
            set
            {
                _participants = value;
                OnPropertyChanged();
            }
        }
        public List<string> Prizes
        {
            get => _prizes;
            set
            {
                _prizes = value;
                OnPropertyChanged();
            }
        }

        // Costruttore della classe
        public Tournament(string name, DateTime date, string game, List<Models.Participant> participants, List<string> prizes)
        {
            _name = name;
            _date = date;
            _game = game;
            _participants = participants;
            _prizes = prizes;
        }

        // Implementazione dell'interfaccia INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
