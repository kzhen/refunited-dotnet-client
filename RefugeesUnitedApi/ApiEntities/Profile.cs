using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RefugeesUnitedApi.ApiEntities
{
  [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
  internal class ProfileWrapper
  {
    [JsonProperty(PropertyName = "profile")]
    public Profile UserProfile { get; set; }
  }

  public class Profile
  {
    [JsonProperty(PropertyName = "primaryEmail")]
    public string Email { get; set; }

    [JsonProperty(PropertyName = "givenName")]
    public string FirstName { get; set; }

    [JsonProperty(PropertyName = "surName")]
    public string Surname { get; set; }
  }
}
