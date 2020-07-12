using System;

namespace GameLogic
{
    public class Player
    {
        private readonly string r_Name;
        private int m_Score;
        private readonly bool r_IsComputer;

        public Player(string i_Name)
        {
            if (IsValidName(i_Name))
            {
                r_Name = i_Name;
            }
            else
            {
                throw new ArgumentException("Given player name is not valid, Should be not empty and at most 20 characters.");
            }
        }

        public Player()
        {
            r_Name = "Computer";
            r_IsComputer = true;
        }

        public bool IsComputer
        {
            get
            {
                return r_IsComputer;
            }
        }

        public string Name
        {
            get
            {
                return r_Name;
            }
        }

        public int Score
        {
            get
            {
                return m_Score;
            }
            set
            {
                m_Score = value;
            }
        }

        public static bool IsValidName(string i_Str)
        {
            bool valid = true;

            // Check length of the given name
            if (i_Str.Length == 0 || i_Str.Length > 20)
            {
                valid = false;
            }
            else
            {
                // Check if all chars is letters
                foreach (char c in i_Str)
                {
                    if (char.IsLetter(c) || char.IsWhiteSpace(c))
                    {
                        continue;
                    }

                    valid = false;
                    break;
                }
            }

            return valid;
        }

        public void AddScore()
        {
            m_Score++;
        }

        public void ResetScore()
        {
            m_Score = 0;
        }
    }
}
