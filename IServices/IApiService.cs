
//Insert Here part of video 2, 51:17 of API

using JOIN.Models;

namespace JOIN.IServices;
    public interface IApiService
    {
   
    Task<TournamentResponse>SearchTournament(string searchTerm, string nextPageToken);
}

