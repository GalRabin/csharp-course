using System;
using System.Collections.Generic;
using System.Linq;

namespace ex2
{
    public class Game
    {
        private const int k_NumOfPlayers = 2;

        private List<Player> m_Players = new List<Player>(k_NumOfPlayers);
        private Player m_CurrentPlayer;
        private Board m_BboardGame;
        private bool N_IsAgainstComputerGame = false;

        public Board BoardGame
        {
            get
            {
                return this.m_BboardGame;
            }
        }
        public void NextPlayer()
        {
            if(this.m_CurrentPlayer != m_Players[0])
            {
                this.m_CurrentPlayer = m_Players[0];
            }
            else
            {
                this.m_CurrentPlayer = m_Players[1];
            }
        }
        public void AddComputerPlayer()
        {
            m_Players.Add(new Player());
        }
        public bool IsAgainstComputerGame
        {
            get
            {
                return this.N_IsAgainstComputerGame;
            }
        }

        public void AddPlayer(string i_Name)
        {
            if (i_Name.Length < 20)
            {
                m_Players.Add(new Player(i_Name));
                this.m_CurrentPlayer = m_Players[0];
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        public void SetBoard(string i_BoardSize)
        {
            m_BboardGame = new Board(i_BoardSize);
        }

        public Cell[,] BoardGameMatrix
        {
            get
            {
                return m_BboardGame.CurrentBoard;
            }
        }

        public Player GetCurrentPlayer()
        {
            return this.m_CurrentPlayer;
        }
        public List<Player> Players
        {
            get
            {
                return this.m_Players;
            }
        }

        public bool IsFinished()
        {
            return m_BboardGame.IsAllCellsRevealed();
        }

        public CellGuess ComputerGuess(Board i_Board)
        {
            CellGuess computerGuess = new CellGuess();
            Random random = new Random();

            while (true)
            {
                int rowGuess = random.Next(0, i_Board.Height);
                int columnGuess = random.Next(0, i_Board.Width);
                computerGuess.RowIndex = rowGuess;
                computerGuess.ColumnIndex = columnGuess;

                if (!this.BoardGame.CurrentBoard[rowGuess, columnGuess].isReveal)
                {
                    break;
                }
            }

            return computerGuess;
        }
        public string GetCurrentWinnnerName()
        {
            string winnerName = "";

            if(this.m_Players.ElementAt(0).Score > this.m_Players.ElementAt(1).Score)
            {
                winnerName = this.m_Players.ElementAt(0).Name;
            }
            else if(this.m_Players.ElementAt(0).Score < this.m_Players.ElementAt(1).Score)
            {
                winnerName = this.m_Players.ElementAt(1).Name;
            }
            else
            {
                winnerName = "even";
            }

            return winnerName;
        }
        public void PrintScore()
        {
            string msg = String.Format("Player 1 score: {0}\n" +
                                        "Player 2 score: {1}",
                                        m_Players[0].Score, m_Players[1].Score);
            Console.WriteLine(msg);
        }
        public void ResetGame()
        {
            foreach (Player player in m_Players)
            {
                player.ResetScore();
            }

            m_BboardGame.ClearBoard();
        }
        public bool CheckIfEqual(List<CellGuess> guesses)
        {
           return m_BboardGame.IsCellsEqual(guesses[0].RowIndex, guesses[0].ColumnIndex, guesses[1].RowIndex, guesses[1].ColumnIndex);
        }
    }
}