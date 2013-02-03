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
    [JsonProperty(PropertyName = "id")]
    public int ProfileId { get; set; }

    [JsonProperty(PropertyName = "primaryEmail")]
    public string Email { get; set; }

    [JsonProperty(PropertyName = "givenName")]
    public string FirstName { get; set; }

    [JsonProperty(PropertyName = "surName")]
    public string Surname { get; set; }

    [JsonProperty(PropertyName = "age")]
    public int? Age { get; set; }

    [JsonProperty(PropertyName = "genderId")]
    public int? GenderId { get; set; }

    [JsonProperty(PropertyName = "isMissingPerson")]
    public bool IsMissingPerson { get; set; }

    [JsonProperty(PropertyName = "countryOfBirthId")]
    public int? CountryOfBirthId { get; set; }

    [JsonProperty(PropertyName = "dialCode")]
    public string DialCode { get; set; }

    [JsonProperty(PropertyName = "cellPhone")]
    public string CellPhoneNumber { get; set; }

    [JsonProperty(PropertyName = "homeTown")]
    public string HomeTown { get; set; }

    [JsonProperty(PropertyName = "tribe")]
    public string Tribe { get; set; }

    [JsonProperty(PropertyName = "nickName")]
    public string NickName { get; set; }
  }
}
