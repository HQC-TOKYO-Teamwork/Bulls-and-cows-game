namespace BullsAndCows.Constants
{
    public class GameConstants
    {
        public const string CommandSuffix = "Command";
        public const string GuessPattern = @"\d{4}";
        public const string GoodbyeMessage = "Good bye!";

        public const string WelcomeMessage = "Welcome to “Bulls and Cows” game." +
                "Please try to guess my secret 4-digit number." +
                "Use 'top' to view the top scoreboard, 'restart'" +
                "to start a new game and 'help'" +
                 " to cheat and 'exit' to quit the game.";

        public const string EnterCommand = "Enter your guess or command: ";
        public const string InvalidOperation = "Invalid operation";
        public const string ScoreBoardTitle = "Scoreboard:";
        public const string ScoreBoardEmpty = "Scoreboard is empty!";
        public const string BullsAndCowsOutPut = "Bulls: {0}, Cows: {1}";
        public const string PlayerInfo = "{0,3}    | {1}";
        public const string WinnerMessageWithOutCheats = "Congratulations! You guessed" +
                " the secret number in {0} attempts.";

        public const string CheatMessageExtention = " attempts and {1} cheats.";
        public const string ScoreBoardHeaderFormat = "  {0,7} | {1}";
        public const string ScoreBoardLineFormat = "{0}. {1}";
        public const string ScoreBoardNameLabel = "Name";
        public const string ScoreBoardGuessesLabel = "Guesses";

        public const char LineChar = '-';
        public const int CharsPerLine = 30;
    }
}
