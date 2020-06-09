using System;
namespace ex2
{
    public class Cell
    {
        private string m_CellValue;
        private bool m_RevealCellState = false;

        public Cell()
        {
            System.Threading.Thread.Sleep(10);
            m_CellValue = getRandomCharacter();
        }

        public Cell(string i_Value)
        {
            m_CellValue = i_Value;
        }
        public bool isReveal
        {
            get
            {
                return this.m_RevealCellState;
            }
        }
        public string CellValue
        {
            get
            {
                return this.m_CellValue;
            }
        }
        private string getRandomCharacter()
        {
            // Random character
            Random rnd = new Random();
            char randomChar = (char)rnd.Next('a', 'z');

            // Random lowercase or uppercase
            if (rnd.Next(1,3) == 1)
            {
                randomChar = char.ToUpper(randomChar);
            }

            return randomChar.ToString();
        }

        public void Reveal()
        {
            m_RevealCellState = true;
        }

        public string GetStringIfRevealed(bool i_ForceReveal = false)
        {
            string returnValue = " ";

            if (m_RevealCellState || i_ForceReveal)
            {
                returnValue = m_CellValue.ToString();
            }

            return returnValue;
        }
    }
}