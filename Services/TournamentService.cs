



using JOIN.Models;

namespace JOIN.Services;

public class TournamentService : RestServiceBase, IApiService
{
    public TournamentService(IConnectivity connectivity, IBarrel cacheBarrel) : base(connectivity, cacheBarrel)
    {
        SetBaseURL(Constants.ApiServiceURL);
        AddHttpHeader("Authorization", "Bearer 0AGymHNi6j0PUyAVSIPicYz0RmWYyMV3F0ObTHdr");
    }

    public async Task<TournamentSearchResult> SearchTournament(string pageNumber)
    {
        var resource = $"https://api.challonge.com/v1/tournaments.json?per_page=25&page={pageNumber}";

        var result = await GetAsync<TournamentSearchResult>(resource);

        return result;
    }

    
}

