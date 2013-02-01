using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RefugeesUnitedApi.ApiEntities
{
  [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
  public class ProfileLoginResult
  {
    [JsonProperty(PropertyName = "authenticated")]
    public bool Authenticated { get; set; }

    [JsonProperty(PropertyName = "verificationRequired")]
    public bool VerficationRequired { get; set; }

    [JsonProperty(PropertyName = "forcePasswordReset")]
    public bool ForcePasswordReset { get; set; }

    [JsonProperty(PropertyName = "profileId")]
    public int ProfileId { get; set; }

    [JsonProperty(PropertyName = "role")]
    public string Role { get; set; }
  }
}
