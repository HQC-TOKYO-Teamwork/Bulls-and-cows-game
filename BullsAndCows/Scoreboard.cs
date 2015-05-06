namespace BullsAndCows
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Constants;
    using Interfaces;

    public class Scoreboard
    {
        private readonly IGameEngine engine;

        public Scoreboard(IGameEngine engine)
        {
            this.engine = engine;
            this.TopPlayers = new List<PlayerInfo>();
        }

        public List<PlayerInfo> TopPlayers { get; set; }

        public override string ToString()
        {
            if (this.TopPlayers.Count > 0)
            {
                StringBuilder scoreBoardBuilder = new StringBuilder();
                scoreBoardBuilder.AppendLine(CreateLine(GameConstants.CharsPerLine, GameConstants.LineChar));
                scoreBoardBuilder.AppendLine(GameConstants.ScoreBoardTitle);
                scoreBoardBuilder.AppendLine(String.Format(GameConstants.ScoreBoardHeaderFormat, GameConstants.ScoreBoardGuessesLabel, GameConstants.ScoreBoardNameLabel)); //todo
                scoreBoardBuilder.AppendLine(CreateLine(GameConstants.CharsPerLine, GameConstants.LineChar));
                int currentPosition = 1;

                foreach (var player in this.TopPlayers)
                {
                    scoreBoardBuilder.AppendLine(String.Format(GameConstants.ScoreBoardLineFormat,
                                      currentPosition, player));
                    currentPosition++;
                }
                scoreBoardBuilder.AppendLine(CreateLine(GameConstants.CharsPerLine, GameConstants.LineChar));
                return scoreBoardBuilder.ToString();
            }
            else
            {
                return Messages.ScoreBoardEmpty;
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
            this.engine.OutputWriter.WriteOutput(Messages.AllowedToEnterScoreboard);
            string playerNick = String.Empty;
            PlayerInfo newPlayer = null;

            while (String.IsNullOrWhiteSpace(playerNick))
            {
                try
                {
                    this.engine.OutputWriter.WriteOutput(Messages.EnterNickname);
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