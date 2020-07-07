using System;
using System.Collections.Generic;
using System.Text;

namespace GameLogic
{
    public class Cell
    {
        private readonly string r_CellValue;
        private bool m_RevealCellState;
        private Player m_PlayerRevealed;
        private Random m_rnd = new Random();

        public Cell()
        {
            // System.Threading.Thread.Sleep(10);
            r_CellValue = getRandomCharacter();
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
                return m_PlayerRevealed;
            }
        }

        private string getRandomCharacter()
        {
            // Random character
            char randomChar = (char)m_rnd.Next('a', 'z');

            // Random lowercase or uppercase
            if (m_rnd.Next(1, 3) == 1)
            {
                randomChar = char.ToUpper(randomChar);
            }

            return randomChar.ToString();
        }

        public void RevealState(bool i_RevealState, Player i_PlayerReveal = null)
        {
            m_RevealCellState = i_RevealState;
            m_PlayerRevealed = i_PlayerReveal;
        }

        public string GetStringIfRevealed(bool i_Force = false)
        {
            string returnValue = " ";

            if (m_RevealCellState || i_Force)
            {
                returnValue = r_CellValue;
            }

            return returnValue;
        }
    }
}
