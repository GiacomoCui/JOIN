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
        private string _game;
        private string _location;
        private string _imageUrl;
        private DateTime _date;
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
        public string Game
        {
            get => _game;
            set
            {
                _game = value;
                OnPropertyChanged();
            }
        }
        public string Location
        {
            get => _location;
            set
            {
                _location = value;
                OnPropertyChanged();
            }
        }
        public string ImageUrl
        {
            get => _imageUrl;
            set
            {
                _imageUrl = value;
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

        public object Value1 { get; }
        public object Value2 { get; }
        public object Value3 { get; }
        public object Value4 { get; }
        public object Value5 { get; }
        public object Value6 { get; }

        // Costruttore della classe
        public Tournament(string name, string game, string location, DateTime date, List<Models.Participant> participants, List<string> prizes)
        {
            _name = name;
            _game = game;
            _location = location;
            _date = date;
            _participants = participants;
            _prizes = prizes;
        }

        public Tournament(object value1, object value2, object value3, object value4, object value5, object value6)
        {
            Value1 = value1;
            Value2 = value2;
            Value3 = value3;
            Value4 = value4;
            Value5 = value5;
            Value6 = value6;
        }

        // Implementazione dell'interfaccia INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
