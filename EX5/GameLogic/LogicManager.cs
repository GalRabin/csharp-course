using System;
using System.Collections.Generic;

namespace GameLogic
{
    public class LogicManager
    {
        private int m_IndexCurrentPlayer;
        private Board m_Board;
        private CellGuessMangaer m_CellGuessManager;
        private MatchManager m_MatchManager;
        
        public LogicManager()
        {
            m_MatchManager = new MatchManager();
            m_CellGuessManager = new CellGuessMangaer();
        }

        public Board Board
        {
            get
            {
                return m_Board;
            }
        }

        public void SetBoardSize(int i_Height, int i_Width)
        {
            m_Board = new Board(i_Height, i_Width);
        }

        public List<Player> GetAllPlayers()
        {
            return m_MatchManager.Players;
        }

        public void AddPlayer(string i_Name = null)
        {
            m_MatchManager.AddPlayer(i_Name);
        }

        public Player CurrentPlayer()
        {
            return m_MatchManager.CurrentPlayer();
        }

        public Player CurrentWinner()
        {
            return m_MatchManager.CurrentWinner();
        }

        private void ValidateGameConfigured()
        {
            if (!(m_MatchManager.IsMatchConfigured() && m_Board != null))
            {
                throw new ArgumentNullException("Game is not configured, Can't start guess, Missing 2 players or board configuration");
            }        
        }

        public bool SetGuess(int i_Row, int i_Column)
        {
            bool correctGuess = false;
            ValidateGameConfigured();
            m_CellGuessManager.SetGuess(i_Row, i_Column);
            // Check if cell Guess is finished for current player
            if (m_CellGuessManager.IsCellGuessFinished())
            {
                // If finished check if cells equal
                correctGuess = m_Board.RevealCellsIfEqual(m_CellGuessManager, CurrentPlayer());
                if (correctGuess)
                {
                    CurrentPlayer().AddScore();
                }
                m_MatchManager.NextPlayer();
                m_CellGuessManager.Clear();
            }

            return correctGuess;
        }

        public bool SetGuess()
        {
            bool correctGuess = false;
            ValidateGameConfigured();
            m_CellGuessManager.SetRandomGuess(Board.Height, Board.Width);
            // Check if cell Guess is finished for current player
            if (m_CellGuessManager.IsCellGuessFinished())
            {
                // If finished check if cells equal
                correctGuess = m_Board.RevealCellsIfEqual(m_CellGuessManager, CurrentPlayer());
                if (correctGuess)
                {
                    m_MatchManager.AddScoreToCurrentPlayer();
                }
                m_MatchManager.NextPlayer();
                m_CellGuessManager.Clear();
            }

            return correctGuess;
        }

        public void RevealBoardGuessState(bool i_RevealState)
        {
            ValidateGameConfigured();
            m_Board.RevealCellState(m_CellGuessManager, i_RevealState);
        }

        public bool IsGameFinished()
        {
            ValidateGameConfigured();
            return m_Board.IsAllCellsRevealed();
        }

        public void ResetGame()
        {
            ValidateGameConfigured();
            m_MatchManager.Clear();
            m_Board.Clear();
            m_CellGuessManager.Clear();
        }
    }
}
