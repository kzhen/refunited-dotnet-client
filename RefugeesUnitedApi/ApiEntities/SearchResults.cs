using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RefugeesUnitedApi.ApiEntities
{
  [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
  public class SearchResults
  {
    public SearchResults()
    {
      Results = new List<Profile>();
    }

    [JsonProperty(PropertyName = "count")]
    public int TotalCount { get; set; }

    public int Count { get { return Results.Count; } }

    [JsonProperty(PropertyName = "queryTime")]
    public int QueryTime { get; set; }

    [JsonProperty(PropertyName = "results")]
    public List<Profile> Results { get; set; }
  }
}
