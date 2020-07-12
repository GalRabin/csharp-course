using System;

namespace GameLogic
{
    public class CellGuessHandler
    {
        private readonly int[,] r_Guesses = new int[2, 2];
        private readonly Random r_Rnd = new Random();
        private int m_CurrentGuess;
        private bool m_IsInit = false;

        public bool IsCellGuessFinished()
        {
            return m_CurrentGuess >= 2;
        }

        public void SetGuess(int i_Row, int i_Column)
        {
            if (IsCellGuessFinished())
            {
                throw new ArgumentException("Number of Guesses is 2, Can't choose more than 2 guesses per session.");
            }
            r_Guesses[m_CurrentGuess,0] = i_Row;
            r_Guesses[m_CurrentGuess, 1] = i_Column;
            m_CurrentGuess++;
            m_IsInit = true;
        }
        public void SetGuess(int i_Row, int i_Column, int i_FirstRowGuess, int i_FirstColumnGuess)
        {
            if (IsCellGuessFinished())
            {
                throw new ArgumentException("Number of Guesses is 2, Can't choose more than 2 guesses per session.");
            }
            else if(i_Row == i_FirstRowGuess && i_Column == i_FirstColumnGuess)
            {
                throw new ArgumentException("Can not Guess the same cell twice");
            }
            r_Guesses[m_CurrentGuess, 0] = i_Row;
            r_Guesses[m_CurrentGuess, 1] = i_Column;
            m_CurrentGuess++;
            m_IsInit = true;
        }

        public void SetRandomGuess(int i_MaxRow, int i_MaxColumn, Cell [,] i_Board)
        {
            if (IsCellGuessFinished())
            {
                throw new ArgumentException("Number of Guesses is 2, Can't choose more than 2 guesses per session.");
            }
            while (true)
            {
                int randomRowGuess = r_Rnd.Next(i_MaxRow);
                int randmColumnGuess = r_Rnd.Next(i_MaxColumn);
                if (!i_Board[randomRowGuess, randmColumnGuess].IsReveal)
                {
                    r_Guesses[m_CurrentGuess, 0] = randomRowGuess;
                    r_Guesses[m_CurrentGuess, 1] = randmColumnGuess;
                    m_CurrentGuess++;
                    m_IsInit = true;
                    break;
                }
                
            }
        }
        public void SetRandomGuess(int i_MaxRow, int i_MaxColumn, Cell[,] i_Board, int i_FirstRowGuess, int i_FirstColumnGuess)
        {
            if (IsCellGuessFinished())
            {
                throw new ArgumentException("Number of Guesses is 2, Can't choose more than 2 guesses per session.");
            }
            while (true)
            {
                int randomRowGuess = r_Rnd.Next(i_MaxRow);
                int randmColumnGuess = r_Rnd.Next(i_MaxColumn);
                if (!i_Board[randomRowGuess, randmColumnGuess].IsReveal && (i_FirstRowGuess != randomRowGuess || i_FirstColumnGuess != randmColumnGuess))
                {
                    r_Guesses[m_CurrentGuess, 0] = randomRowGuess;
                    r_Guesses[m_CurrentGuess, 1] = randmColumnGuess;
                    m_CurrentGuess++;
                    m_IsInit = true;
                    break;
                }

            }
        }

        private void validateGuessNumber(int i_GuessNumber)
        {
            if (i_GuessNumber > 1 || i_GuessNumber < 0)
            {
                throw new ArgumentException("Guess number is between 0 to 1.");
            }
        }

        public int GetColumnGuess(int i_GuessNumber)
        {
            validateGuessNumber(i_GuessNumber);

            return r_Guesses[i_GuessNumber, 1];
        }

        public int GetRowGuess(int i_GuessNumber)
        {
            validateGuessNumber(i_GuessNumber);

            return r_Guesses[i_GuessNumber, 0];
        }

        public int CurrentGuess
        {
            get
            {
                return m_CurrentGuess;
            }
        }

        public int[,] Guesses
        {
            get
            {
                return r_Guesses;
            }
        }

        public bool IsInit
        {
            get
            {
                return m_IsInit;
            }
        }
        public void Clear()
        {
            Array.Clear(r_Guesses, 0, r_Guesses.Length);
            m_CurrentGuess = 0;
            m_IsInit = false;
        }
    }
}
