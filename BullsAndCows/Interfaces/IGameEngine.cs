namespace BullsAndCows.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Cryptography.X509Certificates;
    using System.Text;

    public interface IGameEngine
    {
        char[] DigitForReveal { get; }

        Random RandomGenerator { get; }

        char[] HelpingNumber { get; set; }

        int GuessesCount { get; set; }

        bool IsGuessed { get; set; }

        Scoreboard ScoreBoard { get; }

        int CheatsCount { get; set; }

        string NumberForGuess { get; }

        IInputReader InputReader { get; }

        IOutputWriter OutputWriter { get; }

        void Initialize();

        void Play();
    }
}
