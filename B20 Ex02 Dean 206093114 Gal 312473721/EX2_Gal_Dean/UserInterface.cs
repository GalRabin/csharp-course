using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex2
{
    public class UserInterface
    {
        private Game m_Game;

        private void setUpBoardConfiguration(Game i_Game)
        {
            Console.Write("Enter board size ([4-6]x[4-6], even numbers): ");
            
            while (true)
            {
                try
                {
                    i_Game.SetBoard(Console.ReadLine());
                    break;
                }
                catch (ArgumentException exception)
                {
                    Console.Write("Invalid board size - even and in range 4-6, Pleade new board Size:\n", exception.Message);
                }
            }
        }
        private void addComputerPlayerConfiguration(Game i_Game)
        {
            i_Game.AddComputerPlayer();
        }
        private void addPlayerConfiguration(Game i_Game)
        {
            Console.Write("Enter player name: ");

            while (true)
            {
                try
                {
                    i_Game.AddPlayer(Console.ReadLine());
                    break;
                }
                catch (ArgumentException exception)
                {
                    Console.Write("Invalid player name - Max 20 characters and no spaces\n", exception.Message);
                }
            }
        }

        private bool againstComputerConfiguration()
        {
            bool againstComputer;
            bool againstUpponent;
            Console.Write("Against computer or human upponent (type c|h): ");
            string computerOrPlayer;

            while (true)
            {
                computerOrPlayer = Console.ReadLine();
                againstComputer = computerOrPlayer == "c";
                againstUpponent = computerOrPlayer == "h";

                if (againstComputer || againstUpponent)
                {
                    break;
                }

                Console.Write("Invalid input - u=computer , h=human\n");
            }

            return againstComputer;
        }


        public void ConfigureGame()
        {
            m_Game = new Game();
            // Add first player
            addPlayerConfiguration(m_Game);
            // Add second player or computer
            
            if (!againstComputerConfiguration())
            {
                addPlayerConfiguration(m_Game);
            }
            else
            {
                addComputerPlayerConfiguration(m_Game);
            }
            // Board configuration
            setUpBoardConfiguration(m_Game);
        }

        private string matrixStringRowColumnsNames(int i_TableWidth, int i_ValuesInRow)
        {
            StringBuilder row = new StringBuilder();
            row.Append(matrixAlignCell(" ", i_TableWidth, i_ValuesInRow) + " ");
            
            for (int i = 0; i < i_ValuesInRow; i++)
            {
                string column = ((char)('A' + i)).ToString();
                row.Append(matrixAlignCell(column, i_TableWidth, i_ValuesInRow) + " ");
            }

            return row.ToString();
        }

        private string matrixStringRowSeprator(int i_TableWidth, int i_ValuesInRow)
        {
            StringBuilder row = new StringBuilder();
            row.Append(matrixAlignCell(" ", i_TableWidth, i_ValuesInRow));
            row.Append(new string('=', i_TableWidth++));

            return row.ToString();
        }

        private bool shouldPrintGuess(List<CellGuess> i_Guesses, int i_Row, int i_Column)
        {
            bool print = false;

            foreach (CellGuess guess in i_Guesses)
            {
                if (guess != null && guess.ColumnIndex == i_Column && guess.RowIndex == i_Row)
                {
                    print = true;
                    break;
                }
            }

            return print;
        }

        private string matrixStringLineData(Cell[,] i_Board, int i_RowNumber, List<CellGuess> i_Guesses, int i_TableWidth, int i_ValuesInRow)
        {
            StringBuilder matrixRow = new StringBuilder();
            string rowReadableNumber = (i_RowNumber + 1).ToString();
            matrixRow.Append(matrixAlignCell(rowReadableNumber, i_TableWidth, i_ValuesInRow) + "|");
             
            for (int columnNumber = 0; columnNumber < i_ValuesInRow; columnNumber++)
            {   
                bool print = shouldPrintGuess(i_Guesses, i_RowNumber, columnNumber);
                string cellValue = i_Board[i_RowNumber, columnNumber].GetStringIfRevealed(print);
                matrixRow.Append(matrixAlignCell(cellValue, i_TableWidth, i_ValuesInRow) + "|");
            }

            return matrixRow.ToString();
        }

        private string matrixAlignCell(string i_CellValue, int i_TableWidth, int i_ValuesInRow)
        {
            int cellWidth = i_TableWidth / i_ValuesInRow;
            // Pad to the right
            i_CellValue = i_CellValue.PadRight(cellWidth - (cellWidth - i_CellValue.Length) / 2);
            // Pad to the left
            i_CellValue = i_CellValue.PadLeft(cellWidth);

            return i_CellValue;
        }


        private string boardToPrettyString(Cell[,] i_Board, List<CellGuess> i_Guesses, int i_TableWidth = 59)
        {
            Ex02.ConsoleUtils.Screen.Clear();
            m_Game.PrintScore();
            int valuesInColumn = i_Board.GetLength(0);
            int valuesInRow = i_Board.GetLength(1);
            StringBuilder prettyMatrix = new StringBuilder();
            string rowSeprator = matrixStringRowSeprator(i_TableWidth, valuesInRow);
            prettyMatrix.AppendLine(matrixStringRowColumnsNames(i_TableWidth, valuesInRow));
            prettyMatrix.AppendLine(rowSeprator);

            for (int row = 0; row < valuesInColumn; row++)
            {
                prettyMatrix.AppendLine(matrixStringLineData(i_Board, row, i_Guesses, i_TableWidth, valuesInRow));
                prettyMatrix.AppendLine(rowSeprator);
            }

            return prettyMatrix.ToString();
        }

        private int validateUserRowGuess(string i_Row)
        {
            int rowNumber = -1;
            int boardHeight = m_Game.BoardGameMatrix.GetLength(0);

            if (int.TryParse(i_Row, out rowNumber))
            {
                rowNumber -= 1;
                if (rowNumber < 0 || rowNumber > boardHeight)
                {
                    rowNumber = -1; //throw new ArgumentException();
                }
            }

            return rowNumber;
        }

        private int validateUserColumnGuess(string i_Column)
        {
            int columnNumber = -1;
            int boardWidth = m_Game.BoardGameMatrix.GetLength(1);

            if (i_Column.Length == 1)
            {
                columnNumber = (int)(i_Column[0] - 'A');
                if (columnNumber < 0 || columnNumber > boardWidth)
                {
                    columnNumber = -1; //throw new ArgumentException();
                }
            }

            return columnNumber;
        }

        private CellGuess getGuessFromUser(Player i_CurrentPlayer, int i_GuessNumber)
        {
            CellGuess guess = new CellGuess();
            string outOfRangeMessage = "Your choice is out of the range of te board\n" +
                                       "Please try again";
            string preMessage = String.Format("{0}, now is your turn!\n" +
                "Guess number {1}", i_CurrentPlayer.Name, i_GuessNumber);
            Console.WriteLine(preMessage);

            while (true)
            {
                try
                {
                    int rowGuess = -2;
                    int columnGuess = -2;

                    while (true)
                    {
                        Console.Write("Enter row guess: ");
                        rowGuess = validateUserRowGuess(Console.ReadLine());

                        if(rowGuess >= 0)
                        {
                            break;
                        }

                        Console.WriteLine(outOfRangeMessage);
                    }
                    while (true)
                    {
                        Console.Write("Enter column guess: ");
                        columnGuess = validateUserColumnGuess(Console.ReadLine());
                        
                        if(columnGuess >= 0)
                        {
                            break;
                        }

                        Console.WriteLine(outOfRangeMessage);
                    }
                    guess.RowIndex = rowGuess;
                    guess.ColumnIndex = columnGuess;
                    
                    if (!m_Game.BoardGameMatrix[rowGuess, columnGuess].isReveal)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("You can not guess reveal cell, try again please");
                        System.Threading.Thread.Sleep(2000);
                    }
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("Invalid row argument");
                }
            }

            return guess;
        }

        public void StartGame()
        {
            Player currentPlayer;
            Ex02.ConsoleUtils.Screen.Clear();
            
            while (!m_Game.IsFinished())
            {
                currentPlayer = m_Game.GetCurrentPlayer();
                List<CellGuess> guessesValues = new List<CellGuess>(2) { null, null };
                
                for (int guessNum = 0; guessNum < 2; guessNum++)
                {
                    Console.WriteLine(boardToPrettyString(m_Game.BoardGameMatrix, new List<CellGuess>(2) { null, null }));
                    
                    if (currentPlayer.IsComputer)
                    {
                        guessesValues[guessNum] = m_Game.ComputerGuess(m_Game.BoardGame);
                    }
                    else
                    {
                        guessesValues[guessNum] = getGuessFromUser(currentPlayer, guessNum);
                    }

                    if (guessNum == 1)
                    {
                        if (guessesValues[0].Equals(guessesValues[1]))
                        {
                            Console.WriteLine("You can not choose the same cell to reveal!\n");
                            System.Threading.Thread.Sleep(1000);
                            guessNum--;
                            continue;
                        }
                    }
                    else
                    {
                        Console.WriteLine(boardToPrettyString(m_Game.BoardGameMatrix, guessesValues));
                        System.Threading.Thread.Sleep(2000);
                        Ex02.ConsoleUtils.Screen.Clear();
                    }

                }

                bool successGuess = m_Game.CheckIfEqual(guessesValues);
                if (successGuess)
                {
                    currentPlayer.Score += 1;
                    m_Game.BoardGame.RevealCells(guessesValues);
                    
                    if (!currentPlayer.IsComputer)
                    {
                        Console.WriteLine("Success!\n" +
                                    "+10 points!");
                        System.Threading.Thread.Sleep(2000);
                    }
                }
                else
                {
                    if (!currentPlayer.IsComputer)
                    {
                        Console.WriteLine("Fail attempt, use your brain!");
                        System.Threading.Thread.Sleep(2000);
                    }

                    Console.WriteLine(boardToPrettyString(m_Game.BoardGameMatrix, guessesValues));
                    System.Threading.Thread.Sleep(2000);
                    Ex02.ConsoleUtils.Screen.Clear();
                    m_Game.NextPlayer();
                }
            }
            string vs = "";

            if (m_Game.IsAgainstComputerGame)
            {
                vs = "Computer";
            }
            else
            {
                vs = m_Game.Players[1].Name;
            }

            string finishMsg = string.Format("{0} vs. {1} Game Finished!\n" +
                    "And the winner is...\n", m_Game.Players[0].Name, vs);
            string winnerMsg = string.Format("{0}!!", m_Game.GetCurrentWinnnerName());
            System.Threading.Thread.Sleep(2000);
            Ex02.ConsoleUtils.Screen.Clear();
            Console.WriteLine(finishMsg);
            System.Threading.Thread.Sleep(2000);
            Console.WriteLine(winnerMsg);
            Console.ReadKey();
        }
    }
}