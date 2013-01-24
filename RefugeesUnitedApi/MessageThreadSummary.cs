using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RefugeesUnitedApi
{
  [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
  public class MessageThreadSummary
  {
    [JsonProperty(PropertyName = "id")]
    public int Id { get; set; }

    [JsonProperty(PropertyName = "owningProfileId")]
    public int OwningProfileId { get; set; }

    [JsonProperty(PropertyName = "owningProfileName")]
    public string OwningProfileName { get; set; }

    [JsonProperty(PropertyName = "targetProfileId")]
    public int TargetProfileId { get; set; }

    [JsonProperty(PropertyName = "targetProfileName")]
    public string TargetProfileName { get; set; }

    [JsonProperty(PropertyName = "lastMessageDate")]
    public string LastMessageDate { get; set; }

    [JsonProperty(PropertyName = "numberOfUnread")]
    public int NumberOfUnread { get; set; }

    [JsonProperty(PropertyName = "textSnippet")]
    public string TextSnippet { get; set; }
  }
}
