using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BullsAndCows.Constants;

namespace BullsAndCows
{
    public class Scoreboard
    {
        private const char LineChar = '-';
        private const int CharsPerLine = 30;
        private readonly GameEngine engine;
        private readonly List<PlayerInfo> topPlayers;

        public Scoreboard(GameEngine engine)
        {
            this.engine = engine;
            this.topPlayers = new List<PlayerInfo>();
        }

        public void PrintScoreboard()
        {
            if (topPlayers.Count > 0)
            {
                StringBuilder scoreBoardBuilder = new StringBuilder();
                scoreBoardBuilder.AppendLine(GameConstants.ScoreBoardTitle);
                scoreBoardBuilder.AppendLine(String.Format("  {0,7} | {1}", "Guesses", "Name")); //todo
                scoreBoardBuilder.AppendLine(CreateLine(CharsPerLine, LineChar));
                int currentPosition = 1;

                foreach (var player in this.topPlayers)
                {
                    scoreBoardBuilder.AppendLine(String.Format("{0}| {1}",
                                      currentPosition, player));
                    scoreBoardBuilder.AppendLine(CreateLine(CharsPerLine, LineChar));
                    currentPosition++;
                }
                this.engine.OutputWriter.WriteOutput(scoreBoardBuilder.ToString());
            }
            else
            {
                this.engine.OutputWriter.WriteOutput(GameConstants.ScoreBoardEmpty);
            }
        }

        public void AddPlayerToScoreboard(int guesses)
        {
            if (this.engine.CheatsCount > 0)
            {
                this.engine.OutputWriter.WriteOutput("You are not allowed to enter the top scoreboard.");
            }
            else
            {
                if (topPlayers.Count < 5)
                {
                    topPlayers.Add(CreatePlayer(guesses));
                }
                else if (topPlayers[4].Guesses > guesses)
                {
                    topPlayers.RemoveAt(4);
                    topPlayers.Add(CreatePlayer(guesses));
                }
                this.topPlayers.Sort();
            }
        }

        private PlayerInfo CreatePlayer(int guesses)
        {
            this.engine.OutputWriter.WriteOutput("You can add your nickname to top scores!");
            string playerNick = String.Empty;
            PlayerInfo newPlayer = null;

            while (String.IsNullOrWhiteSpace(playerNick))
            {
                try
                {
                    this.engine.OutputWriter.WriteOutput("Enter your nickname: ");
                    playerNick = this.engine.InputReader.ReadInput();
                    newPlayer = new PlayerInfo(playerNick, guesses);
                }
                catch (ArgumentOutOfRangeException e)
                {
                    this.engine.OutputWriter.WriteOutput(e.Message);
                }
                catch (ArgumentException e)
                {
                    this.engine.OutputWriter.WriteOutput(e.Message);
                }
            }
            return newPlayer;
        }

        private static string CreateLine(int charCount, char ch)
        {
            return new String(ch, charCount);
        }
    }
}
