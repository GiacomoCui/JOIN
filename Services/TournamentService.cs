
using System.Net.Http.Headers;

namespace JOIN.Services;

public class TournamentService : RestServiceBase, IApiService
{
    public TournamentService(IConnectivity connectivity, IBarrel cacheBarrel) : base(connectivity, cacheBarrel)
    {
        SetBaseURL(Constants.ApiServiceURL);
        AddHttpHeader("Accept","application/json");
        AddHttpHeader("User-Agent","ILJOIN");
        AddHttpHeader("Api-Key", $"{Constants.ApiKey}");

    }

    public async Task<TournamentResponse> SearchTournaments(string nextPageToken = "1")
    {
        var resourceUri = $"https://api.challonge.com/v2/tournaments.json?page=1&per_page=25";

        var result = await GetAsync<TournamentResponse>(resourceUri, 1);

        return result;
    }

}

