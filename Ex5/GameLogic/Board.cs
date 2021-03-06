﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace GameLogic
{
    public class Board
    {
        private int m_RevealedCells;
        private readonly Cell[,] r_CurrentBoard;
        private readonly HashSet<string> r_RandomObjectsList = new HashSet<string>();
        private static readonly Random sr_Rnd = new Random();

        public Board(int i_Height, int i_Width)
        {
            if (!(4 <= i_Height && i_Height <= 6 && 4 <= i_Width && i_Width <= 6 && i_Width * i_Height % 2 == 0))
            {
                throw new ArgumentException("Board size is not valid." + Environment.NewLine + 
                    "Size should be Height in range 4-6 and Width in range 4-6 with even number of cells.");
            }

            r_CurrentBoard = new Cell[i_Height, i_Width];
            SetBoard();
        }

        public int Height
        {
            get
            {
                return r_CurrentBoard.GetLength(0);
            }
        }

        public int Width
        {
            get
            {
                return r_CurrentBoard.GetLength(1);
            }
        }

        public Cell[,] CurrentBoard
        {
            get
            {
                return r_CurrentBoard;
            }
        }
        public List<string> RandomObjects
        {
            get
            {
                return r_RandomObjectsList.ToList<string>();
            }
        }

        private int getRandomHorizontalIndex(List<int> i_FreeIndexs)
        {
            int random = sr_Rnd.Next(i_FreeIndexs.Count);
            int freeIndex = i_FreeIndexs[random];
            i_FreeIndexs.Remove(freeIndex);

            return freeIndex;
        }

        public void SetBoard()
        {
            List<int> freeIndexs = Enumerable.Range(0, r_CurrentBoard.Length).ToList();

            for (int row = 0; row < Height; row++)
            {
                for (int column = 0; column < Width; column++)
                {
                    // Set cell only if null
                    if (r_CurrentBoard[row, column] == null)
                    {
                        // Horizontal index
                        int horizontalIndex = (row * Width) + column;
                        freeIndexs.Remove(horizontalIndex);
                        r_CurrentBoard[row, column] = new Cell();
                        string value = r_CurrentBoard[row, column].GetStringIfRevealed(true);
                        // Get random matching cell
                        int randomHorizontalIndex = getRandomHorizontalIndex(freeIndexs);
                        int randomRow = randomHorizontalIndex / Width;
                        int randomColumn = randomHorizontalIndex % Width;
                        r_CurrentBoard[randomRow, randomColumn] = new Cell(value);
                        r_RandomObjectsList.Add(value);
                    }
                }
            }
        }

        public bool RevealCellsIfEqual(CellGuessHandler i_Guess, Player i_PlayerReveal)
        {
            string firstCellValue = r_CurrentBoard[i_Guess.GetRowGuess(0), i_Guess.GetColumnGuess(0)].GetStringIfRevealed(true);
            string secondCellValue = r_CurrentBoard[i_Guess.GetRowGuess(1), i_Guess.GetColumnGuess(1)].GetStringIfRevealed(true);
            bool isReavling = firstCellValue == secondCellValue;
            if (isReavling)
            {
                RevealCellState(i_Guess, true, i_PlayerReveal);
                m_RevealedCells += 2;
            }

            return isReavling;
        }

        public void RevealCellState(CellGuessHandler i_Guess, bool i_RevealCells, Player i_PlayerReveal = null)
        {
            for(int i = 0; i < i_Guess.CurrentGuess; i++)
            {
                r_CurrentBoard[i_Guess.GetRowGuess(i), i_Guess.GetColumnGuess(i)].RevealState(i_RevealCells, i_PlayerReveal);
            }
        }

        public void Clear()
        {
            for (int row = 0; row < r_CurrentBoard.GetLength(0); row++)
            {
                for (int column = 0; column < r_CurrentBoard.GetLength(1); column++)
                {
                    r_CurrentBoard[row, column] = null;
                }
            }

            m_RevealedCells = 0;
            SetBoard();
        }

        public bool IsAllCellsRevealed()
        {
            return m_RevealedCells == (Width * Height);
        }
    }
}
