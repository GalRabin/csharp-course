using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace GameLogic
{
    public class CellGuessMangaer
    {
        private int[,] m_Guesses;
        private int m_CurrentGuess;
        private Random m_Rnd = new Random();

        public CellGuessMangaer()
        {
            m_Guesses = new int[2, 2];
            m_CurrentGuess = 0;
        }

        public bool IsCellGuessFinished()
        {
            return m_CurrentGuess >= 3;
        }

        public void SetGuess(int i_Row, int i_Column)
        {
            if (IsCellGuessFinished())
            {
                throw new ArgumentException("Number of Guesses is 2, Can't choose more than 2 guesses per session.");
            }
            m_Guesses[m_CurrentGuess,0] = i_Row;
            m_Guesses[m_CurrentGuess, 1] = i_Column;
        }

        public void SetRandomGuess(int i_MaxRow, int i_MaxColumn)
        {
            if (IsCellGuessFinished())
            {
                throw new ArgumentException("Number of Guesses is 2, Can't choose more than 2 guesses per session.");
            }
            m_Guesses[m_CurrentGuess, 0] = m_Rnd.Next(i_MaxRow);
            m_Guesses[m_CurrentGuess, 1] = m_Rnd.Next(i_MaxColumn);
        }

        public int GetColumnGuess(int i_GuessNumber)
        {
            if (i_GuessNumber >= 2 || i_GuessNumber < 0)
            {
                throw new ArgumentException("Guess number is between 0 to 1.");
            }

            return m_Guesses[i_GuessNumber, 1];
        }

        public int GetRowGuess(int i_GuessNumber)
        {
            if (i_GuessNumber >= 2 || i_GuessNumber < 0)
            {
                throw new ArgumentException("Guess number is between 0 to 1.");
            }

            return m_Guesses[i_GuessNumber, 0];
        }

        public void Clear()
        {
            Array.Clear(m_Guesses, 0, m_Guesses.Length);
            m_CurrentGuess = 0;
        }


    }
}
