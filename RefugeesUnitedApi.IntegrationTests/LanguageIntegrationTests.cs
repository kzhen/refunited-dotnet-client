using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RefugeesUnitedApi.Tests
{
  [TestClass]
  public class LanguageIntegrationTests
  {
    public static ApiRequestSettings requestSettings = new ApiRequestSettings()
    {
    };

    [TestMethod]
    public void ShouldReturnListOfLanguages()
    {
      ApiRequest apiRequest = new ApiRequest(requestSettings);

      var languages = apiRequest.GetLanguages();

      Assert.AreEqual(5, languages.Count);
    }
  }
}
