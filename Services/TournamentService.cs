﻿using RestSharp;


namespace JOIN.Services;

public class TournamentService : RestServiceBase, IApiService
{

    public RestClient client;

    public TournamentService(IConnectivity connectivity, IBarrel cacheBarrel) : base(cacheBarrel, connectivity)
    {
        client = new RestClient("https://api.challonge.com/v2/");
    }

    public Task<Tournament> SearchSingleTournament(string torunamentId)
    {
        var request = new RestRequest("tournaments/{id}.json");
        request.AddUrlSegment("id", torunamentId);
        request.AddHeader("Authorization-Type", "v1");
        request.AddHeader("Authorization", $"{Constants.ApiKey}");
        request.AddHeader("Content-Type", "application/vnd.api+json");
        request.AddHeader("Accept", "application/json");

        var response = client.Get<Tournament>(request);

        return Task.FromResult(response);
    }

    public Task<TournamentResponse> SearchTournaments(string nextPageToken)
    {
        var request = new RestRequest("tournaments.json");
        request.AddParameter("page", nextPageToken);
        request.AddParameter("per_page", 2);
        request.AddHeader("Authorization-Type", "v1");
        request.AddHeader("Authorization", $"{Constants.ApiKey}");
        request.AddHeader("Content-Type", "application/vnd.api+json");
        request.AddHeader("Accept", "application/json");

        var response = client.Get<TournamentResponse>(request);

        return Task.FromResult(response);
    }



}

