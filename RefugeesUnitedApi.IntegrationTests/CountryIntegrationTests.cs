using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RefugeesUnitedApi.Tests
{
  [TestClass]
  public class CountryIntegrationTests
  {
    public static ApiRequestSettings requestSettings = new ApiRequestSettings()
    {
    };

    [TestMethod]
    public void ShouldReturnAListOfCountries()
    {
      ApiRequest request = new ApiRequest(requestSettings);

      var countries = request.GetCountries();

      Assert.IsNotNull(countries);
      Assert.AreEqual(230, countries.Count);
    }
  }
}
