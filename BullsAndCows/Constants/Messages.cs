namespace BullsAndCows.Constants
{
    public static class Messages
    {
        public const string GoodbyeMessage = "Good bye!";
        public const string WelcomeMessage = "Welcome to “Bulls and Cows” game." +
                "Please try to guess my secret 4-digit number." +
                "Use 'top' to view the top scoreboard, 'restart'" +
                "to start a new game and 'help'" +
                 " to cheat and 'exit' to quit the game.";

        public const string NotAllowedToEnterScoreboard = "You are not allowed to enter the top scoreboard.";
        public const string AllowedToEnterScoreboard = "You can add your nickname to top scores!";
        public const string EnterNickname = "Enter your nickname: ";
        public const string EnterCommand = "Enter your guess or command: ";
        public const string ScoreBoardEmpty = "Scoreboard is empty!";
        public const string WinnerMessageWithOutCheats = "Congratulations! You guessed" +
                " the secret number in {0} attempts.";
        public const string CheatMessageExtention = "{0} attempts and {1} cheats.";
    }
}
