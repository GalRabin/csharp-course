using System;
using System.Collections.Generic;
using System.Linq;

namespace GameLogic
{
    public class GameManager
    {
        private Board m_Board;
        private readonly CellGuessHandler r_CellGuessManager;
        private readonly MatchHandler r_MatchManager;
        
        public GameManager()
        {
            r_MatchManager = new MatchHandler();
            r_CellGuessManager = new CellGuessHandler();
        }

        public string GetCellValue(int i_RowIndex, int i_ColumnIndex, bool i_ForceReveal = false)
        {
            return Board.CurrentBoard[i_RowIndex, i_ColumnIndex].GetStringIfRevealed(i_ForceReveal);
        }
        public int GetCellPlayer(int i_RowIndex, int i_ColumnIndex)
        {
            return Board.CurrentBoard[i_RowIndex, i_ColumnIndex].PlayerRevealed != null ?
                r_MatchManager.Players.IndexOf(Board.CurrentBoard[i_RowIndex, i_ColumnIndex].PlayerRevealed) : -1;
        }
        public bool GetCellRevealState(int i_RowIndex, int i_ColumnIndex)
        {
            return Board.CurrentBoard[i_RowIndex, i_ColumnIndex].IsReveal;
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
            // Throw exception if not in range of 4-6 both in width or height
            m_Board = new Board(i_Height, i_Width);
        }

        public List<Player> GetAllPlayers()
        {
            return r_MatchManager.Players;
        }

        public void AddPlayer(string i_Name = null)
        {
            r_MatchManager.AddPlayer(i_Name);
        }
        public bool isComputerTurn
        {
            get
            {
                return this.CurrentPlayer().IsComputer;
            }
        }
        public int GetPlayerScore(int i_PlayerIndex)
        {
            return r_MatchManager.Players[i_PlayerIndex].Score;
        }
        public Player CurrentPlayer()
        {
            return r_MatchManager.CurrentPlayer();
        }
        public bool IsNewTurn()
        {
            return r_CellGuessManager.IsCellGuessFinished();
        }
        public bool IsCurrentPlayerComputer()
        {
            return r_MatchManager.CurrentPlayer().IsComputer;
        }

        public string CurrentWinnerName()
        {

            return r_MatchManager.CurrentWinner() != null ? r_MatchManager.CurrentWinner().Name : null;
        }

        private void validateGameConfigured()
        {
            if (!(r_MatchManager.IsMatchConfigured() && m_Board != null))
            {
                throw new ArgumentNullException("Game is not configured, Can't start guess, " +
                                                "Missing 2 players or board configuration");
            }        
        }

        public bool SetGuess(int i_Row, int i_Column)
        {
            bool correctGuess = false;
            validateGameConfigured();
            r_CellGuessManager.SetGuess(i_Row, i_Column);

            // Check if cell Guess is finished for current player
            if (r_CellGuessManager.IsCellGuessFinished())
            {
                // If finished check if cells equal
                correctGuess = m_Board.RevealCellsIfEqual(r_CellGuessManager, CurrentPlayer());
                if (correctGuess)
                {
                    r_MatchManager.CurrentPlayer().AddScore();
                }
            }

            return correctGuess;
        }
        public void ClearTurn()
        {
            r_MatchManager.NextPlayer();
            r_CellGuessManager.Clear();
        }
        public bool SetGuess()
        {
            bool correctGuess = false;
            validateGameConfigured();
            r_CellGuessManager.SetRandomGuess(Board.Height, Board.Width);
            if (r_CellGuessManager.IsCellGuessFinished())
            {
                // If finished check if cells equal
                correctGuess = m_Board.RevealCellsIfEqual(r_CellGuessManager, CurrentPlayer());
                if (correctGuess)
                {
                    r_MatchManager.AddScoreToCurrentPlayer();
                }
            }

            return correctGuess;
        }

        public void ForceRevealBoardGuessState(bool i_RevealState)
        {
            validateGameConfigured();
            m_Board.RevealCellState(r_CellGuessManager, i_RevealState);
        }

        public bool IsGameFinished()
        {
            validateGameConfigured();
            return m_Board.IsAllCellsRevealed();
        }

        public void ResetGame()
        {
            validateGameConfigured();
            r_MatchManager.Clear();
            m_Board.Clear();
            r_CellGuessManager.Clear();
        }
    }
}
