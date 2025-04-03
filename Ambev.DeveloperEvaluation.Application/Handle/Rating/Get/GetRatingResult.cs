using System.Text.Json.Serialization;

namespace Ambev.DeveloperEvaluation.Application.Handle.Rating.Get;

public class GetRatingResult
{
    #region properties

    [JsonIgnore]
    public Guid Id { get; set; }
    public int Rate { get; set; }
    public int Count { get; set; }
    public DateTime CreatedAt { get; set; }

    #endregion
}