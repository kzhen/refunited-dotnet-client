using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefugeesUnitedApi.ApiEntities
{
  [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
  public class Language
  {
    [JsonProperty(PropertyName = "languageid")]
    public int Id { get; set; }

    [JsonProperty(PropertyName = "name")]
    public string Name { get; set; }

    [JsonProperty(PropertyName = "languageCode")]
    public string CountryCode { get; set; }
  }

  [JsonObject]
  internal class LanguageCollectionWrapper
  {
    [JsonProperty(PropertyName = "languages")]
    public List<Language> Languages { get; set; }
  }
}
