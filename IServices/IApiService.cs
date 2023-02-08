
//Insert Here part of video 2, 51:17 of API

using JOIN.Models;

namespace JOIN.IServices;
    public interface IApiService
    {
    Task<TournamentSearchResult> SearchTournament(string nextPageToken = "");
    }

