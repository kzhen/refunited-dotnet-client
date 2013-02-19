using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefugeesUnitedApi.Tests
{
  [TestClass]
  public class VerificationIntegrationTests
  {
    public static ApiRequestSettings requestSettings = new ApiRequestSettings()
    {
    };

    [TestClass]
    public class CompleteVerificationTests
    {
      [TestMethod]
      public void ShouldCompleteVerification()
      {
      }
    }

    [TestClass]
    public class EmailVerificationCodeGenerationTests
    {
      [TestMethod]
      public void ShouldGenerateEmailVerificationCode()
      {
        int profileId = 324784;
        string email = "";

        IApiRequest apiRequest = new ApiRequest(requestSettings);

        var verifcationCode = apiRequest.GetEmailVerificationCode(profileId, email);

        Assert.IsNotNull(verifcationCode);
        Assert.AreEqual(email, verifcationCode.Email);
      }
    }

    [TestClass]
    public class PhoneVerificationCodeGenerationTests
    {
      [TestMethod]
      public void ShouldGeneratePhoneVerificationCode()
      {
        int profileId = 324784;
        string countryCode = "";
        string phoneNumber = "";

        IApiRequest apiRequest = new ApiRequest(requestSettings);

        var verificationResponse = apiRequest.GetPhoneVerificationCode(profileId, countryCode, phoneNumber);

        Assert.IsNotNull(verificationResponse);
        Assert.AreEqual(countryCode, verificationResponse.CountryCode);
      }
    }
  }
}
