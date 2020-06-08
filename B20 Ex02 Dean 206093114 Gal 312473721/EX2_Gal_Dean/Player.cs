using System;
namespace ex2
{
    public class Player
    {
        private string m_Name;
        private int m_Score = 0;
        private bool m_IsComputer = false; 

        public Player(string i_Name)
        {
            if (IsValidName(i_Name))
            {
                this.m_Name = i_Name;
            }
            else
            {
                throw new ArgumentException();
            }
        }
        public Player()
        {
            this.m_Name = "Computer";
            this.m_IsComputer = true;
        }
        public bool IsComputer
        {
            get
            {
                return this.m_IsComputer;
            }
            set
            {
                this.m_IsComputer = value;
            }
        }
        public string Name
        {
            get
            {
                return m_Name;
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
                this.m_Score = value;
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
                    if (!Char.IsLetter(c))
                    {
                        valid = false;
                        break;
                    }
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