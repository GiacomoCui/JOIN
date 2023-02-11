﻿using RestSharp;


namespace JOIN.Services;

public class TournamentService : RestServiceBase, IApiService
{

    public RestClient client;

    public TournamentService(IConnectivity connectivity, IBarrel cacheBarrel) : base(cacheBarrel, connectivity)
    {
        client = new RestClient("https://api.challonge.com/v2/");
    }

    public async Task<TournamentResponse> SearchTournaments(string nextPageToken = "1")
    {
        var request = new RestRequest("tournaments.json?page=1&per_page=10");
        request.AddHeader("Authorization-Type", "v1");
        request.AddHeader("Authorization", $"{Constants.ApiKey}");
        request.AddHeader("Content-Type", "application/vnd.api+json");
        request.AddHeader("Accept", "application/json");

        var response = client.Get<TournamentResponse>(request);

        return response;

    }

}
