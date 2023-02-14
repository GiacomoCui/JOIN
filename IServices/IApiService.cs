
namespace JOIN.IServices;
    public interface IApiService
    {
   
    Task<TournamentResponse>SearchTournaments(int nextPageToken = 1);
}

