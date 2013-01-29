using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefugeesUnitedApi.ApiEntities
{
  [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
  internal class CountriesWrapper
  {
    [JsonProperty(PropertyName = "countries")]
    public IDictionary<int, Country> Countries { get; set; }
  }

  [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
  public class Country
  {
    public int Id { get; set; }

    [JsonProperty(PropertyName = "name")]
    public string Name { get; set; }

    [JsonProperty(PropertyName = "isoCode")]
    public string IsoCode { get; set; }

    [JsonProperty(PropertyName = "dialCode")]
    public string DialCode { get; set; }

    internal static Country BuildCountry(dynamic expando)
    {
      return new Country
      {
        Id = expando.Id,
        Name = expando.name,
        IsoCode = expando.isoCode,
        DialCode = expando.dialCode
      };
    }
  }
}
