using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameUI
{
    public partial class FormGame : Form
    {
        private static readonly Color[] sr_PairsColor = new Color[2]{Color.Yellow, Color.Blue}; 
        private bool m_ValidConfiguration = false;
        private GameLogic.GameManager m_Game;
        private int m_BoardHeight = 4;
        private int m_BoardWidth = 4;
        private bool m_IsButtonClicked = false;

        public FormGame()
        {
            m_Game = new GameLogic.GameManager();
            while (!ensureValidConfiguration()) ;
            InitializeComponent();

        }
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            initializeForm();
        }

        private void initializeForm()
        {
            this.tableLayoutPanelBoard.ColumnCount = this.m_BoardWidth;
            this.tableLayoutPanelBoard.RowCount = this.m_BoardHeight;
            int rowPercentage = 100 / m_BoardHeight;
            int columnPercentage = 100 / m_BoardWidth;
            for (int i = 0; i < this.tableLayoutPanelBoard.ColumnCount; i++)
            {
                this.tableLayoutPanelBoard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, columnPercentage));
            }
            for (int i = 0; i < this.tableLayoutPanelBoard.RowCount; i++)
            {
                this.tableLayoutPanelBoard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, rowPercentage));
            }

            for (int i = 0; i < this.tableLayoutPanelBoard.RowCount; i++)
            {
                for (int j = 0; j < this.tableLayoutPanelBoard.ColumnCount; j++)
                {
                    CellButton cellButton = createCellButton(i, j);
                    this.tableLayoutPanelBoard.Controls.Add(cellButton, j, i);
                }
            }

            this.labelCurrentPlayer.Text = string.Format("Current Player: {0}", m_Game.CurrentPlayer().Name);
            this.labelFirstScore.Text = string.Format("First Player Pairs: {0}", this.m_Game.GetPlayerScore(0));
            this.labelSecondScore.Text = string.Format("Second Player Pairs: {0}", this.m_Game.GetPlayerScore(1));

            manage();
        }
        private void manage()
        {
            while (!m_Game.IsGameFinished())
            {
                if (m_Game.IsNewTurn())
                {
                    m_Game.ClearTurn();
                    changeLabels();

                    if (m_Game.isComputerTurn)
                    {
                        disablePlayerButtons();
                        computerPlay();
                        enablePlayerButtons();
                    }
                    else
                    {
                        while (!m_IsButtonClicked) ;
                    }
                }
            }

            showFinishMessage();
            m_Game.ResetGame();
        }
        private CellButton createCellButton(int i_RowIndex, int i_ColumnIndex)
        {
            CellButton cellButton = new CellButton(i_RowIndex, i_ColumnIndex);
            cellButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));
            cellButton.Location = new System.Drawing.Point(3, 3);
            cellButton.Name = string.Format("Button {0}, {1}", i_RowIndex, i_ColumnIndex);
            cellButton.Size = new System.Drawing.Size(110, 78);
            cellButton.TabIndex = this.tableLayoutPanelBoard.TabIndex + i_RowIndex + i_ColumnIndex;
            cellButton.Text = "";
            cellButton.UseVisualStyleBackColor = true;
            cellButton.Click += new EventHandler(this.cellButton_Click);
            
            return cellButton;
        }
        private bool ensureValidConfiguration()
        {
            if (!m_ValidConfiguration)
            {
                FormLogin win = new FormLogin();
                win.ShowDialog();
                if (win.ClosedByStart)
                {
                    this.m_BoardHeight = win.BoardHeight;
                    this.m_BoardWidth = win.BoardWidth;
                    m_Game.SetBoardSize(win.BoardHeight, win.BoardWidth);
                    m_Game.AddPlayer(win.FirstPlayerName);
                    m_Game.AddPlayer(win.SecondPlayerName);
                    m_ValidConfiguration = true;
                }
            }

            return m_ValidConfiguration;
        }

        private void cellButton_Click(object sender, EventArgs e)
        {
            m_IsButtonClicked = true;
            bool correct = m_Game.SetGuess((sender as CellButton).RowIndex, (sender as CellButton).ColumnIndex);
            handleBoard(correct);
            m_IsButtonClicked = false;
        }
        private void computerPlay()
        {
            bool correct = m_Game.SetGuess();
            handleBoard(correct);
            correct = m_Game.SetGuess();
            handleBoard(correct);
        }

        private void handleBoard(bool i_Correct) 
        {    
            if (!i_Correct)
            {
                m_Game.ForceRevealBoardGuessState(true);
                changeBoard();
                System.Threading.Thread.Sleep(1000);
                m_Game.ForceRevealBoardGuessState(false);
            }

            changeBoard();
        }

        private void disablePlayerButtons()
        {
            foreach (Control crl in this.tableLayoutPanelBoard.Controls)
            {
                crl.Enabled = false;
            }
        }

        private void enablePlayerButtons()
        {
            foreach (Control crl in this.tableLayoutPanelBoard.Controls)
            {
                crl.Enabled = true;
            }
        }
        private void changeBoard()
        {
            for (int i = 0; i < this.tableLayoutPanelBoard.RowCount; i++)
            {
                for (int j = 0; j < this.tableLayoutPanelBoard.ColumnCount; j++)
                {
                    Control crl = this.tableLayoutPanelBoard.GetControlFromPosition(j, i);
                    crl.Text = this.m_Game.GetCellValue(i, j);

                    if (this.m_Game.GetCellPlayer(i, j) != -1)
                    {
                        crl.BackColor = sr_PairsColor[this.m_Game.GetCellPlayer(i, j)];
                        crl.Enabled = false;
                    }
                }
            }

            this.tableLayoutPanelBoard.Refresh();
        }
        private void changeLabels()
        {
            this.labelCurrentPlayer.Text = string.Format("Current Player: {0}", m_Game.CurrentPlayer().Name);
            this.labelFirstScore.Text = string.Format("First Player Pairs: {0}", this.m_Game.GetPlayerScore(0));
            this.labelSecondScore.Text = string.Format("Second Player Pairs: {0}", this.m_Game.GetPlayerScore(1));
            this.labelCurrentPlayer.Refresh();
            this.labelFirstScore.Refresh();
            this.labelSecondScore.Refresh();
        }

        private void showFinishMessage()
        {
            string winner = m_Game.CurrentWinnerName();
            string totalMsg = null;

            if (winner != null)
            {
                totalMsg = string.Format("Game Finished!" + Environment.NewLine +
                               "The Winner is..." + Environment.NewLine +
                               "{0}", winner);
            }
            else
            {
                totalMsg = string.Format("Game Finished!" + Environment.NewLine +
                            "Unfortunetly " + Environment.NewLine +
                               "{0}", winner);
            }

            MessageBox.Show(totalMsg);
        }
        
      
    }
}
