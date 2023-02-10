
namespace JOIN.TournamentResponseModel;

public class TournamentResponse
{
    [JsonPropertyName("tournaments")]
    public List<Tournament> Tournaments { get; set; }

    [JsonPropertyName("meta")]
    public Meta Meta { get; set; }

    [JsonPropertyName("links")]
    public Links Links { get; set; }
}

public class Tournament
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("url")]
    public string Url { get; set; }

    // altre proprietà relative ai tornei
}

public class Meta
{
    [JsonPropertyName("total_pages")]
    public int TotalPages { get; set; }

    [JsonPropertyName("page")]
    public int Page { get; set; }

    [JsonPropertyName("per_page")]
    public int PerPage { get; set; }

    [JsonPropertyName("total_count")]
    public int TotalCount { get; set; }
}

public class Links
{
    [JsonPropertyName("self")]
    public string Self { get; set; }

    [JsonPropertyName("next")]
    public string Next { get; set; }

    [JsonPropertyName("prev")]
    public string Prev { get; set; }
}
