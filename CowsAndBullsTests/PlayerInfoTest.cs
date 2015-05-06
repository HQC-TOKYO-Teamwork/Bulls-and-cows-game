namespace CowsAndBullsTests
{
    using System;
    using BullsAndCows;
    using BullsAndCows.Constants;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class PlayerInfoTest
    {
        [TestMethod]
        public void TestCreatePlayerInfo()
        {
            PlayerInfo info = new PlayerInfo("nick", 3);
            Assert.IsInstanceOfType(info, typeof(PlayerInfo), "Should return instance of PlayerInfo");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "ArgumentOutOfRangeException expected")]
        public void TestPlayerInfoWithNegativeGuesses()
        {
            PlayerInfo info = new PlayerInfo("nick", -3);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "ArgumentException expected")]
        public void TestPlayerInfoWithEmptyStringNick()
        {
            PlayerInfo info = new PlayerInfo("", 3);
        }

        [TestMethod]
        public void TestPlayerInfoToString()
        {
            PlayerInfo info = new PlayerInfo("nickname", 3);
            var expected = String.Format(GameConstants.PlayerInfo, info.Guesses, info.NickName);
            Assert.AreEqual(info.ToString(), expected);
        }

        [TestMethod]
        public void TestPlayerInfoCompareWithDifferentGuessCount()
        {
            PlayerInfo firstPlayer = new PlayerInfo("nickname", 3);
            PlayerInfo secondPlayer = new PlayerInfo("nick", 2);
            Assert.IsTrue(firstPlayer.CompareTo(secondPlayer) > 0,
                "Player with less guesses should be first");
        }

        [TestMethod]
        public void TestPlayerInfoCompareWithEqualGuessCount()
        {
            PlayerInfo firstPlayer = new PlayerInfo("nickname", 2);
            PlayerInfo secondPlayer = new PlayerInfo("nick", 2);
            Assert.IsTrue(firstPlayer.CompareTo(secondPlayer) > 0,
                "When players have equal guesses they should be ordered by their nicknames");
        }
    }
}
