namespace CowsAndBullsTests
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using BullsAndCows;
    using BullsAndCows.Constants;
    using BullsAndCows.InputReaders;
    using BullsAndCows.OutputWriters;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ScoreBoardTest
    {
        public GameEngine Engine { get; set; }

        [TestInitialize]
        public void GameEngineInitialize()
        {
            this.Engine = new GameEngine(new ConsoleReader(), new ConsoleWriter());
        }

        [TestMethod]
        public void TestAddPlayerToEmptyScoreBoard()
        {
            PlayerInfo player = new PlayerInfo("nickname", 5);
            this.Engine.ScoreBoard.AddPlayerToScoreboard(player);

            Assert.AreEqual(player, this.Engine.ScoreBoard.TopPlayers[0], "The new player should be at position 1");
        }

        [TestMethod]
        public void TestAddPlayerWithTooManyGuessesToFullScoreBoard()
        {
            PlayerInfo player = new PlayerInfo("nickname", 10);
            this.Engine.ScoreBoard.TopPlayers = new List<PlayerInfo>
            {
                new PlayerInfo("nick", 5),
                new PlayerInfo("nick", 6),
                new PlayerInfo("nick", 7),
                new PlayerInfo("nick", 8),
                new PlayerInfo("nick", 9),
            };
            this.Engine.ScoreBoard.AddPlayerToScoreboard(player);

            Assert.IsFalse(this.Engine.ScoreBoard.TopPlayers.Contains(player), "The new player should not be added to the scoreboard");
        }

        [TestMethod]
        public void TestAddPlayerToFullScoreBoard()
        {
            PlayerInfo player = new PlayerInfo("nickname", 4);
            this.Engine.ScoreBoard.TopPlayers = new List<PlayerInfo>
            {
                new PlayerInfo("nick", 5),
                new PlayerInfo("nick", 6),
                new PlayerInfo("nick", 7),
                new PlayerInfo("nick", 8),
                new PlayerInfo("nick", 9),
            };
            this.Engine.ScoreBoard.AddPlayerToScoreboard(player);

            Assert.AreEqual(player, this.Engine.ScoreBoard.TopPlayers[0], "The new player should not be added to the scoreboard");
        }

        [TestMethod]
        public void TestGetPlayerInfo()
        {
            string nickname = "testname";
            int guesses = 5;
            PlayerInfo expected = new PlayerInfo(nickname, guesses);

            using (StringReader sr = new StringReader(nickname))
            {
                Console.SetIn(sr);
                PlayerInfo player = this.Engine.ScoreBoard.GetPlayerInfo(guesses);

                Assert.IsTrue(player.CompareTo(expected) == 0,
                    "Expected to get PlayerInfo with nickname equal to testname and guesses equal to 5");
            }
        }

        [TestMethod]
        public void TestGetPlayerInfoWithEmptyStringAsNickname()
        {
            string nickname = "testname";
            int guesses = 5;
            PlayerInfo expected = new PlayerInfo(nickname, guesses);

            using (StringReader sr = new StringReader("" + Environment.NewLine + nickname))
            {
                Console.SetIn(sr);
                PlayerInfo player = this.Engine.ScoreBoard.GetPlayerInfo(guesses);

                Assert.IsTrue(player.CompareTo(expected) == 0,
                    "Expected to get PlayerInfo with nickname equal to testname and guesses equal to 5");
            }
        }

        [TestMethod]
        public void TestPrintEmptyScoreBoard()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                this.Engine.OutputWriter.WriteOutput(this.Engine.ScoreBoard.ToString());

                string expected = Messages.ScoreBoardEmpty + Environment.NewLine;
                Assert.AreEqual(sw.ToString(), expected, "Expected message for empty scoreboard");
            }
        }

        [TestMethod]
        public void TestPrintFullScoreBoard()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                this.Engine.ScoreBoard.TopPlayers = new List<PlayerInfo>
                {
                    new PlayerInfo("nick", 5),
                    new PlayerInfo("nick", 6),
                    new PlayerInfo("nick", 7),
                    new PlayerInfo("nick", 8),
                    new PlayerInfo("nick", 9)
                };

                var line = new String(GameConstants.LineChar, GameConstants.CharsPerLine);
                var scoreBoard = new StringBuilder(line + Environment.NewLine);
                scoreBoard.AppendLine(GameConstants.ScoreBoardTitle);
                scoreBoard.AppendLine(String.Format(GameConstants.ScoreBoardHeaderFormat,
                    GameConstants.ScoreBoardGuessesLabel,
                    GameConstants.ScoreBoardNameLabel));
                scoreBoard.AppendLine(line);

                var position = 1;
                foreach (var player in this.Engine.ScoreBoard.TopPlayers)
                {
                    scoreBoard.AppendLine(String.Format(GameConstants.ScoreBoardLineFormat,
                                      position, player));
                    position++;
                }
                scoreBoard.AppendLine(line);
                var expected = scoreBoard + Environment.NewLine;
             
                this.Engine.OutputWriter.WriteOutput(this.Engine.ScoreBoard.ToString());
                Assert.AreEqual(sw.ToString(), expected, "Expected message for empty scoreboard");
            }
        }
    }
}
