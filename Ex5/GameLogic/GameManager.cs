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
            return m_Board.CurrentBoard[i_RowIndex, i_ColumnIndex].GetStringIfRevealed(i_ForceReveal);
        }
        public int GetCellPlayer(int i_RowIndex, int i_ColumnIndex)
        {
            return m_Board.CurrentBoard[i_RowIndex, i_ColumnIndex].PlayerRevealed != null ?
                r_MatchManager.Players.IndexOf(m_Board.CurrentBoard[i_RowIndex, i_ColumnIndex].PlayerRevealed) : -1;
        }
        public bool GetCellRevealState(int i_RowIndex, int i_ColumnIndex)
        {
            return m_Board.CurrentBoard[i_RowIndex, i_ColumnIndex].IsReveal;
        }

        public void SetBoardSize(int i_Height, int i_Width)
        {
            // Throw exception if not in range of 4-6 both in width or height
            m_Board = new Board(i_Height, i_Width);
        }

        public List<string> GetRandomObjects()
        {
            return m_Board.RandomObjects;
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
                return CurrentPlayer().IsComputer;
            }
        }
        public int GetPlayerScore(int i_PlayerIndex)
        {
            return r_MatchManager.Players[i_PlayerIndex].Score;
        }
        private Player CurrentPlayer()
        {
            return r_MatchManager.CurrentPlayer();
        }

        public int CurrentPlayerIndex()
        {
            return r_MatchManager.Players.IndexOf(r_MatchManager.CurrentPlayer());
        }

        public string GetPlayerName(int i_PlayerIndex)
        {
            return r_MatchManager.Players[i_PlayerIndex].Name;
        }
        public bool IsNewTurn()
        {
            return r_CellGuessManager.IsCellGuessFinished() || r_CellGuessManager.CurrentGuess == 0;
        }
        public bool IsTurnOver()
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
        public bool IsGuessesInit()
        {
            return r_CellGuessManager.IsInit;
        }
        private void validateGameConfigured()
        {
            if (!(r_MatchManager.IsMatchConfigured() && m_Board != null))
            {
                throw new ArgumentNullException("Game is not configured, Can't start guess, " +
                                                "Missing 2 players or board configuration");
            }
        }
        public int GetColumnGuess(int i_GuessNumber)
        {
            return r_CellGuessManager.GetColumnGuess(i_GuessNumber);
        }
        public int GetRowGuess(int i_GuessNumber)
        {
            return r_CellGuessManager.GetRowGuess(i_GuessNumber);
        }
        public bool SetGuess(int i_Row, int i_Column)
        {
            bool correctGuess = false;
            validateGameConfigured();

            if (r_CellGuessManager.CurrentGuess == 0)
            {
                r_CellGuessManager.SetGuess(i_Row, i_Column);
                m_Board.CurrentBoard[i_Row, i_Column].Incheck = true;
            }
            else if (r_CellGuessManager.CurrentGuess == 1)
            {
                r_CellGuessManager.SetGuess(i_Row, i_Column, r_CellGuessManager.GetRowGuess(0), r_CellGuessManager.GetColumnGuess(0));
                m_Board.CurrentBoard[i_Row, i_Column].Incheck = true;
            }
            // Check if cell Guess is finished for current player
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

        public bool SetGuess()
        {
            bool correctGuess = false;
            validateGameConfigured();
            if (r_CellGuessManager.CurrentGuess == 0)
            {
                r_CellGuessManager.SetRandomGuess(m_Board.Height, m_Board.Width, m_Board.CurrentBoard);
                m_Board.CurrentBoard[r_CellGuessManager.GetRowGuess(0), r_CellGuessManager.GetColumnGuess(0)].Incheck = true;
            }
            else if (r_CellGuessManager.CurrentGuess == 1)
            {
                r_CellGuessManager.SetRandomGuess(m_Board.Height, m_Board.Width, m_Board.CurrentBoard, r_CellGuessManager.GetRowGuess(0), r_CellGuessManager.GetColumnGuess(0));
                m_Board.CurrentBoard[r_CellGuessManager.GetRowGuess(1), r_CellGuessManager.GetColumnGuess(1)].Incheck = true;
            }

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

        public bool IsCellInCheck(int i_RowIndex, int i_ColumnIndex)
        {
            return m_Board.CurrentBoard[i_RowIndex, i_ColumnIndex].Incheck;
        }

        public void ForceRevealBoardGuessState(bool i_RevealState)
        {
            validateGameConfigured();
            m_Board.RevealCellState(r_CellGuessManager, i_RevealState);
        }
        public void ClearTurn(bool i_DontChangePlayer)
        {
            if (!i_DontChangePlayer)
            {
                r_MatchManager.NextPlayer();
            }
            m_Board.CurrentBoard[r_CellGuessManager.GetRowGuess(0), r_CellGuessManager.GetColumnGuess(0)].Incheck = false;
            m_Board.CurrentBoard[r_CellGuessManager.GetRowGuess(1), r_CellGuessManager.GetColumnGuess(1)].Incheck = false;
            r_CellGuessManager.Clear();
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
