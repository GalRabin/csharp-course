using System;
using System.Linq;
using System.Collections.Generic;

namespace ex2
{
    public class Board
    {
        private int m_Height = 0;
        private int m_Width = 0;
        private int m_RevealedCells = 0;
        private Cell[,] m_CurrentBoard;

        public Board(string i_BoardSize)
        {
            parseBoardSize(i_BoardSize);
            m_CurrentBoard = new Cell[m_Height, m_Width];
            SetBoard();
        }

        private void parseBoardSize(string phrase)
        {
            if (phrase.Length != 3)
            {
                throw new ArgumentException();
            }
            else if (!char.IsDigit(phrase[0]) || !char.IsDigit(phrase[2]) || phrase[1] != 'x')
            {
                throw new ArgumentException();
            }
            else
            {
                m_Height = int.Parse(phrase[0].ToString());
                m_Width = int.Parse(phrase[2].ToString());

                if (m_Width % 2 != 0 | m_Height % 2 != 0)
                {
                    throw new ArgumentException();
                }
            }
        }
        public int Height
        {
            get
            {
                return this.m_Height;
            }
        }
        public int Width
        {
            get
            {
                return this.m_Width;
            }
        }
        public Cell[,] CurrentBoard
        {
            get
            {
                return this.m_CurrentBoard;
            }
        }

        private int getRandomHorizontalIndex(List<int> i_FreeIndexs)
        {
            Random rnd = new Random();
            int random = rnd.Next(i_FreeIndexs.Count);
            int freeIndex = i_FreeIndexs[random];
            i_FreeIndexs.Remove(freeIndex);

            return freeIndex;
        }

        public void SetBoard()
        {
            List<int> freeIndexs = Enumerable.Range(0, m_CurrentBoard.Length).ToList();
            
            for (int row = 0; row < m_Height; row++)
            {
                for (int column = 0; column < m_Width; column++)
                {
                    // Set cell only if null
                    if (m_CurrentBoard[row, column] == null)
                    {
                        // Horizontal index
                        int horizontalIndex = (row * m_Width) + column;
                        freeIndexs.Remove(horizontalIndex);
                        m_CurrentBoard[row, column] = new Cell();
                        string value = m_CurrentBoard[row, column].GetStringIfRevealed(true);
                        // Get random matching cell
                        int randomHorizontalIndex = getRandomHorizontalIndex(freeIndexs);
                        int randomRow = randomHorizontalIndex / m_Width;
                        int randomColumn = randomHorizontalIndex % m_Width;
                        m_CurrentBoard[randomRow, randomColumn] = new Cell(value);
                    }
                }
            }
        }
        public void RevealCells(List<CellGuess> i_Gussess)
        {
            this.m_CurrentBoard[i_Gussess[0].RowIndex, i_Gussess[0].ColumnIndex].Reveal();
            this.m_CurrentBoard[i_Gussess[1].RowIndex, i_Gussess[1].ColumnIndex].Reveal();
            this.m_RevealedCells += 2;
        }

        public void ClearBoard()
        {
            for (int row = 0; row < m_CurrentBoard.GetLength(0); row++)
            {
                for (int column = 0; column < m_CurrentBoard.GetLength(1); column++)
                {
                    m_CurrentBoard[row, column] = null;
                }
            }

            SetBoard();
        }
        
        public bool IsAllCellsRevealed()
        {
            return this.m_RevealedCells == (m_Width * m_Height);
        }

        public bool IsCellsEqual(int i_FirstRow, int i_FirstColumn, int i_SecondRow, int secondColumn)
        {
            bool isEqual = false;
            string firstCellValue = m_CurrentBoard[i_FirstRow, i_FirstColumn].GetStringIfRevealed(true);
            string secondCellValue = m_CurrentBoard[i_SecondRow, secondColumn].GetStringIfRevealed(true);

            if (firstCellValue == secondCellValue)
            {
                //currentBoard[firstRow, col1].Reveal();
                isEqual = true;
            }

            return isEqual;
        }
    }
}