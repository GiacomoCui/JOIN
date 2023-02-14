



namespace JOIN.Services;

public class TournamentRestService : RestServiceBase, IApiService
{
    public TournamentRestService(IConnectivity connectivity, IBarrel cacheBarrel) : base(cacheBarrel, connectivity)
    {
        //SetBaseURL(Constants.ApiServiceURL);
    }

    //public async Task<>
}

