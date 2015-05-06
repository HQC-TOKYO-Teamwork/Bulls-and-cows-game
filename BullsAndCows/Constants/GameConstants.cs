namespace BullsAndCows.Constants
{
    public static class GameConstants
    {
        public const string CommandSuffix = "Command";
        public const string GuessPattern = @"\d{4}";     
        public const string ScoreBoardTitle = "Scoreboard:";
        public const string BullsAndCowsOutPut = "Bulls: {0}, Cows: {1}";
        public const string PlayerInfo = "{0,3}    | {1}";     
        public const string ScoreBoardHeaderFormat = "  {0,7} | {1}";
        public const string ScoreBoardLineFormat = "{0}. {1}";
        public const string ScoreBoardNameLabel = "Name";
        public const string ScoreBoardGuessesLabel = "Guesses";
        public const char LineChar = '-';
        public const int CharsPerLine = 30;
    }
}
