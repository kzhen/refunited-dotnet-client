using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RefugeesUnitedApi.ApiEntities;

namespace RefugeesUnitedApi.Tests
{
  [TestClass]
  public class MessagingIntegrationTests
  {
    public static ApiRequestSettings requestSettings = new ApiRequestSettings()
    {
    };

    [TestClass]
    public class UnreadMessagesTest
    {
      [TestMethod]
      public void ShouldReturn2UnreadMessageCount()
      {
        ApiRequest apiRequest = new ApiRequest(requestSettings);

        int profileId = 280976;

        ProfileUnreadMessage unread = apiRequest.GetUnreadMessages(profileId);

        Assert.AreEqual(1, unread.UnreadMessages);
      }
    }

    [TestClass]
    public class ProfileMessageCollectionTests
    {
      [TestMethod]
      public void ShouldReturnAListOfMessages()
      {
        ApiRequest apiRequest = new ApiRequest(requestSettings);
        int profileId = 280976;

        ProfileMessageCollection collection = apiRequest.GetMessageCollection(profileId);

        Assert.AreEqual(2, collection.threads.Length);
      }
    }

    [TestClass]
    public class ProfileMessageThread
    {
      [TestMethod]
      public void ShouldReturnAMessageThread()
      {
        ApiRequest apiRequest = new ApiRequest(requestSettings);
        int profileId = 280976;
        int targetProfileId = 324317;

        MessageThread thread = apiRequest.GetMessageThread(profileId, targetProfileId);
        

        Assert.IsNotNull(thread);
        Assert.AreEqual(2, thread.TotalMessageCount);
      }
    }
  }
}
