
namespace JOIN.Services;

public class TournamentService : RestServiceBase, IApiService
{
    public TournamentService(IConnectivity connectivity, IBarrel cacheBarrel) : base(connectivity, cacheBarrel)
    {
        SetBaseURL(Constants.ApiServiceURL);
        AddHttpHeader("Authorization", "Bearer 0AGymHNi6j0PUyAVSIPicYz0RmWYyMV3F0ObTHdr");
        AddHttpHeader("Accept", "application/json");
    }

    public async Task<TournamentResponse> SearchTournament(string searchTerm, string nextPageToken)
    {
        var resourceUri = $"https://api.challonge.com/v1/tournaments/{searchTerm}.json?per_page=25&page={nextPageToken}";

        var result = await GetAsync<TournamentResponse>(resourceUri, 1);

        return result;
    }

}

