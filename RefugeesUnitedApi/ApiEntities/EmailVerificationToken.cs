using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefugeesUnitedApi.ApiEntities
{
  [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
  public class EmailVerificationToken
  {
    [JsonProperty(PropertyName = "token")]
    public string Token { get; set; }

    [JsonProperty(PropertyName = "email")]
    public string Email { get; set; }
  }
}
