﻿
using CommunityToolkit.Mvvm.Input;
using JOIN;
using JOIN_App.ViewControls.Utenti;
using System.Windows.Input;

namespace JOIN_App.ViewModels.ProfiloUtente;

[QueryProperty(nameof(Utente),nameof(Utente))]
public partial class PaginaProfiloModificabileViewModel : ObservableObject
{

    [ObservableProperty]
    Utente user;

    public PaginaProfiloModificabileViewModel(Utente user)
    {
        this.user = user;
    }

    [RelayCommand]
    async Task Salva()
    {
        string nuovo_nome = "";

        do
        {
            nuovo_nome = await Shell.Current.DisplayPromptAsync("MODIFICA PROFILO", "Inserisci nuovo Nickname");
        }
        while (string.IsNullOrWhiteSpace(nuovo_nome));
    }
    /*
    

    [ObservableProperty]
    Utente user;
   

    

    [RelayCommand]
     async Task SaveButton()
    {

        if (string.IsNullOrWhiteSpace(nome)) return;

        if (connectivity.NetworkAccess != NetworkAccess.Internet)
        {
            await Shell.Current.DisplayAlert("Errore:Niente Internet", "Connesione Internet Assente", "OK"); //Messaggio d'errore
            return;
        }

        this.user.nome = nome;

    }*/
}