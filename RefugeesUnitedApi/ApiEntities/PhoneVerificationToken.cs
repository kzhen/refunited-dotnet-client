using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefugeesUnitedApi.ApiEntities
{
  [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
  public class PhoneVerificationToken
  {
    [JsonProperty(PropertyName = "token")]
    public String Token { get; set; }

    [JsonProperty(PropertyName = "dialCode")]
    public string CountryCode { get; set; }
  }
}
