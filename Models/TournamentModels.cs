
//Insert Here the JSON to C# Model

using System.Text.Json.Serialization;

namespace JOIN.Models;

public class Links
{
    [JsonPropertyName("self")]
    public string Self { get; set; }

    [JsonPropertyName("next")]
    public string Next { get; set; }

    [JsonPropertyName("prev")]
    public string Prev { get; set; }
}

public class Meta
{
    [JsonPropertyName("count")]
    public int Count { get; set; }
}

public class TournamentSearchResult
{
    [JsonPropertyName("data")]
    public List<object> Data { get; set; }

    [JsonPropertyName("included")]
    public List<object> Included { get; set; }

    [JsonPropertyName("meta")]
    public Meta Meta { get; set; }

    [JsonPropertyName("links")]
    public Links Links { get; set; }
}


