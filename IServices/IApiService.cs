
namespace JOIN.IServices;
    public interface IApiService
    {
   
    Task<TournamentResponse>SearchTournaments(string nextPageToken);
}

