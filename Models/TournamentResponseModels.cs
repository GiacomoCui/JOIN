
namespace JOIN.TournamentResponseModel;


public class TournamentResponse
{
    [JsonPropertyName("data")]
    public List<Tournament> Data { get; set; }

    [JsonPropertyName("meta")]
    public Meta Meta { get; set; }

    [JsonPropertyName("links")]
    public Links Links { get; set; }
}

public class Tournament
{
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("attributes")]
    public Attributes Attributes { get; set; }

    [JsonPropertyName("relationships")]
    public Relationships Relationships { get; set; }

    [JsonPropertyName("links")]
    public Links Links { get; set; }
}

public class Attributes
{
    [JsonPropertyName("url")]
    public string Url { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("state")]
    public string State { get; set; }

    [JsonPropertyName("private")]
    public bool @Private { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }

    [JsonPropertyName("tournamentType")]
    public string TournamentType { get; set; }

    [JsonPropertyName("fullChallongeUrl")]
    public string FullChallongeUrl { get; set; }

    [JsonPropertyName("liveImageUrl")]
    public string LiveImageUrl { get; set; }

    [JsonPropertyName("notifyUponTournamentEnds")]
    public bool NotifyUponTournamentEnds { get; set; }

    [JsonPropertyName("notifyUponMatchesOpen")]
    public bool NotifyUponMatchesOpen { get; set; }

    [JsonPropertyName("thirdPlaceMatch")]
    public bool ThirdPlaceMatch { get; set; }

    [JsonPropertyName("acceptAttachments")]
    public bool AcceptAttachments { get; set; }

    [JsonPropertyName("signupCap")]
    public object SignupCap { get; set; }

    [JsonPropertyName("openSignup")]
    public bool OpenSignup { get; set; }

    [JsonPropertyName("checkInDuration")]
    public int? CheckInDuration { get; set; }

    [JsonPropertyName("hideSeeds")]
    public bool HideSeeds { get; set; }

    [JsonPropertyName("sequentialPairings")]
    public bool SequentialPairings { get; set; }

    [JsonPropertyName("timestamps")]
    public Timestamps Timestamps { get; set; }

    public Relationships RelationshipsCopy { get; set; }

}

public class Links
{
    [JsonPropertyName("related")]
    public string Related { get; set; }

    [JsonPropertyName("meta")]
    public Meta Meta { get; set; }

    [JsonPropertyName("self")]
    public string Self { get; set; }

    [JsonPropertyName("next")]
    public string Next { get; set; }

    [JsonPropertyName("prev")]
    public string Prev { get; set; }
}

public class Matches
{
    [JsonPropertyName("links")]
    public Links Links { get; set; }
}

public class Meta
{
    [JsonPropertyName("count")]
    public int? Count { get; set; }
}

public class Participants
{
    [JsonPropertyName("links")]
    public Links Links { get; set; }
}

public class Relationships
{
    [JsonPropertyName("matches")]
    public Matches Matches { get; set; }

    [JsonPropertyName("participants")]
    public Participants Participants { get; set; }
}



public class Timestamps
{
    [JsonPropertyName("startsAt")]
    public DateTime? StartsAt { get; set; }

    [JsonPropertyName("createdAt")]
    public DateTime CreatedAt { get; set; }

    [JsonPropertyName("updatedAt")]
    public DateTime UpdatedAt { get; set; }

    [JsonPropertyName("completedAt")]
    public object CompletedAt { get; set; }
}

