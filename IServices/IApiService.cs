
namespace JOIN.IServices;
    public interface IApiService
    {
   
    Task<TournamentResponse>SearchTournaments(string nextPageToken);

    Task<Tournament> SearchSingleTournament(string torunamentId);
}

