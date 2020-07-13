using System;

namespace GameLogic
{
    public class Cell
    {
        private readonly string r_CellValue;
        private bool m_RevealCellState;
        private Player m_PlayerRevealed = null;
        private bool m_IsInCheck = false;
        private static readonly Random sr_Rnd = new Random();

        public Cell()
        {
            r_CellValue = getRandomCharacter();
        }

        public Cell(string i_Character)
        {
            r_CellValue = i_Character;
        }

        public bool IsReveal
        {
            get
            {
                return m_RevealCellState;
            }
        }

        public Player PlayerRevealed
        {
            get
            {
                return m_PlayerRevealed;//IsReveal ? m_PlayerRevealed : null;
            }
        }
        public bool Incheck
        {
            get
            {
                return m_IsInCheck;
            }
            set
            {
                m_IsInCheck = value;
            }
        }
        private string getRandomCharacter()
        {
            // Random character
            char randomChar = (char)sr_Rnd.Next('a', 'z');

            // Random lowercase or uppercase
            if (sr_Rnd.Next(1, 3) == 1)
            {
                randomChar = char.ToUpper(randomChar);
            }

            return randomChar.ToString();
        }

        public void RevealState(bool i_RevealState, Player i_PlayerReveal = null)
        {
            m_RevealCellState = i_RevealState;
            m_PlayerRevealed = i_PlayerReveal;

            /*if(i_PlayerReveal == null)
            {
                m_IsInCheck = i_RevealState;
            }*/
        }

        public string GetStringIfRevealed(bool i_Force = false)
        {
            string returnValue = null;

            if (m_RevealCellState || i_Force)
            {
                returnValue = r_CellValue;
            }

            return returnValue;
        }
    }
}
