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

        public Scoreboard(GameEngine engine)
        {
            this.engine = engine;
            this.TopPlayers = new List<PlayerInfo>();
        }

        public List<PlayerInfo> TopPlayers { get; set; }

        public string ToString()
        {
            if (this.TopPlayers.Count > 0)
            {
                StringBuilder scoreBoardBuilder = new StringBuilder();
                scoreBoardBuilder.AppendLine(GameConstants.ScoreBoardTitle);
                scoreBoardBuilder.AppendLine(String.Format(GameConstants.ScoreBoardLineFormat, GameConstants.ScoreBoardGuessesLabel, GameConstants.ScoreBoardNameLabel)); //todo
                scoreBoardBuilder.AppendLine(CreateLine(CharsPerLine, LineChar));
                int currentPosition = 1;

                foreach (var player in this.TopPlayers)
                {
                    scoreBoardBuilder.AppendLine(String.Format(GameConstants.ScoreBoardLineFormat,
                                      currentPosition, player));
                    scoreBoardBuilder.AppendLine(CreateLine(CharsPerLine, LineChar));
                    currentPosition++;
                }
                return scoreBoardBuilder.ToString();
            }
            else
            {
                return GameConstants.ScoreBoardEmpty;
            }
        }

        public void AddPlayerToScoreboard(PlayerInfo player)
        {
            if (this.TopPlayers.Count < 5)
            {
                this.TopPlayers.Add(player);
            }
            else if (this.TopPlayers[4].Guesses > player.Guesses)
            {
                this.TopPlayers.RemoveAt(4);
                this.TopPlayers.Add(player);
            }
            this.TopPlayers.Sort();
        }

        public PlayerInfo GetPlayerInfo(int guesses)
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
