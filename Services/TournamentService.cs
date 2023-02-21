using RestSharp;


namespace JOIN.Services;

public class TournamentService : RestServiceBase, IApiService
{

    public RestClient client;

    public TournamentService(IConnectivity connectivity, IBarrel cacheBarrel) : base(cacheBarrel, connectivity)
    {
        client = new RestClient("https://api.challonge.com/v2/");
    }

    public Task<TournamentResponse> SearchTournaments(string nextPageToken)
    {
        var request = new RestRequest("tournaments.json");
        request.AddParameter("page", nextPageToken);
        request.AddParameter("per_page", 50);
        request.AddHeader("Authorization-Type", "v1");
        request.AddHeader("Authorization", $"{Constants.ApiKey}");
        request.AddHeader("Content-Type", "application/vnd.api+json");
        request.AddHeader("Accept", "application/json");

        var response = client.Get<TournamentResponse>(request);

        return Task.FromResult(response);

        //chiamata per API indicata dalla documentazione, ma non funziona sempre su android

        //var options = new RestClientOptions("https://api.challonge.com/")
        //{
        //    MaxTimeout = -1,
        //};
        //var client = new RestClient(options);
        //var request = new RestRequest("/v1/application/tournaments.json", Method.Get);
        //request.AddHeader("Authorization-Type", "v1");
        //request.AddHeader("Content-Type", "application/vnd.api+json");
        //request.AddHeader("Accept", "application/json");
        //request.AddHeader("Authorization", "Lxd3KzJZO36ugZkRzJu2Yy1Piv4pHwFuUa1IYBVH");
        //RestResponse response = await client.ExecuteAsync(request);
        //Console.WriteLine(response.Content);


        //return null;
    }



}

