namespace BullsAndCows
{
    using System;
    using Constants;

    public class PlayerInfo : IComparable<PlayerInfo>
    {
        private string nickName;
        private int guesses;

        public PlayerInfo(string nickName, int guesses)
        {
            this.NickName = nickName;
            this.Guesses = guesses;
        }

        public string NickName
        {
            get { return this.nickName; }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(GameConstants.NickNameTooShort);
                }
                this.nickName = value;
            }
        }

        public int Guesses
        {
            get { return this.guesses; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(GameConstants.InvalidGuesses);
                }
                this.guesses = value;
            }
        }

        public int CompareTo(PlayerInfo other)
        {
            if (this.Guesses.CompareTo(other.Guesses) == 0)
            {
                return this.NickName.CompareTo(other.NickName);
            }
            else
            {
                return this.Guesses.CompareTo(other.Guesses);
            }
        }

        public override string ToString()
        {
            string result = String.Format(GameConstants.PlayerInfo, Guesses, NickName);
            return result;
        }
    }
}