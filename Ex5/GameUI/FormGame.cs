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
        private static readonly Color[] sr_PairsColor = new Color[2] { Color.LightGreen, Color.MediumPurple };
        private static readonly Color sr_DefaultBoardButtonBackColor = default(Color);
        private static readonly Color sr_DefaultBoardButtonForeColor = Color.Black;
        private static readonly Color sr_WrongBoardButtonForeColor = Color.Red;
        private bool m_ValidConfiguration = false;
        private GameLogic.GameManager m_Game;
        private int m_BoardHeight = 4;
        private int m_BoardWidth = 4;
        private bool m_LoginFormClosedByX = false;
        private bool m_WantToPlay = true;

        public FormGame()
        {
            m_Game = new GameLogic.GameManager();

            while (!ensureValidConfiguration() && !m_LoginFormClosedByX) ;
            InitializeComponent();

            if (m_LoginFormClosedByX)
            {
                m_WantToPlay = false;
            }
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            initializeForm();

            if (m_LoginFormClosedByX)
            {
                notifyNoLegalConfiguration();
            }
        }

        private void initializeForm()
        {
            createTable();
            addButtonsToTable();
            setLabels();
            updateCellsBoardAfterClick();
            Refresh();

            if (m_Game.isComputerTurn)
            {
                computerPlay();
            }
        }
        private void createTable()
        {
            tableLayoutPanelBoard.ColumnCount = m_BoardWidth;
            tableLayoutPanelBoard.RowCount = m_BoardHeight;
            int rowPercentage = 100 / m_BoardHeight;
            int columnPercentage = 100 / m_BoardWidth;

            for (int i = 0; i < tableLayoutPanelBoard.ColumnCount; i++)
            {
                tableLayoutPanelBoard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, columnPercentage));
            }

            for (int i = 0; i < tableLayoutPanelBoard.RowCount; i++)
            {
                tableLayoutPanelBoard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, rowPercentage));
            }
        }
        private void addButtonsToTable()
        {
            for (int i = 0; i < tableLayoutPanelBoard.RowCount; i++)
            {
                for (int j = 0; j < tableLayoutPanelBoard.ColumnCount; j++)
                {
                    CellButton cellButton = createCellButton(i, j);
                    tableLayoutPanelBoard.Controls.Add(cellButton, j, i);
                }
            }
        }
        private void setLabels()
        {
            labelCurrentPlayer.Text = Messages.CurrentPlayerLabelText(m_Game.GetPlayerName(m_Game.CurrentPlayerIndex()));
            labelCurrentPlayer.BackColor = sr_PairsColor[m_Game.CurrentPlayerIndex()];
            labelFirstScore.Text = Messages.FirstPlayerLabelText(m_Game.GetPlayerScore(0));
            labelFirstScore.BackColor = sr_PairsColor[0];
            labelSecondScore.Text = Messages.SecondPlayerLabelText(m_Game.GetPlayerScore(1));
            labelSecondScore.BackColor = sr_PairsColor[1];
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
            cellButton.TabIndex = tableLayoutPanelBoard.TabIndex + i_RowIndex + i_ColumnIndex;
            cellButton.Text = "";
            cellButton.BackColor = sr_DefaultBoardButtonBackColor;
            cellButton.ForeColor = sr_DefaultBoardButtonForeColor;
            cellButton.UseVisualStyleBackColor = true;
            cellButton.Click += new EventHandler(cellButton_Click);

            return cellButton;
        }
        private bool ensureValidConfiguration()
        {
            if (!m_ValidConfiguration)
            {
                while (true)
                {
                    FormLogin win = new FormLogin();
                    win.ShowDialog();

                    if (win.ClosedByStart)
                    {
                        try
                        {
                            m_BoardHeight = win.BoardHeight;
                            m_BoardWidth = win.BoardWidth;
                            m_Game.SetBoardSize(win.BoardHeight, win.BoardWidth);
                            m_Game.AddPlayer(win.FirstPlayerName);
                            m_Game.AddPlayer(win.SecondPlayerName);
                            m_ValidConfiguration = true;
                            break;
                        }
                        catch (ArgumentException ae)
                        {
                            MessageBox.Show(Messages.k_ArgumentExceptionNameLabelInLoginForm);
                        }
                    }
                    else
                    {
                        m_LoginFormClosedByX = true;
                        m_BoardHeight = win.BoardHeight;
                        m_BoardWidth = win.BoardWidth;
                        m_Game.SetBoardSize(win.BoardHeight, win.BoardWidth);
                        m_Game.AddPlayer(" ");
                        m_Game.AddPlayer(" ");
                        break;
                    }
                }
            }

            return m_ValidConfiguration;
        }

        private void cellButton_Click(object sender, EventArgs e)
        {
            if (!m_Game.isComputerTurn)
            {
                while (true)
                {
                    try
                    {
                        bool correct = m_Game.SetGuess((sender as CellButton).RowIndex, (sender as CellButton).ColumnIndex);
                        (sender as CellButton).InCheck = m_Game.IsCellInCheck((sender as CellButton).RowIndex, (sender as CellButton).ColumnIndex);
                        handleBoardAfterClick(correct);
                        break;
                    }
                    catch (ArgumentException ae)
                    {

                    }
                }
            }

            while (m_Game.isComputerTurn && !m_Game.IsGameFinished())
            {
                computerPlay();
            }

            if (m_Game.IsGameFinished())
            {
                handleGameOver();
            }
        }

        private void handleGameOver()
        {
            showFinishMessage();

            if (m_WantToPlay)
            {
                m_Game.ResetGame();
                updateCellsBoardAfterClick();
                updateLabels();
            }
            else
            {
                Close();
            }
        }
        private void computerPlay()
        {
            bool correct = m_Game.SetGuess();
            handleBoardAfterClick(correct);
            correct = m_Game.SetGuess();
            handleBoardAfterClick(correct);
        }

        private void handleBoardAfterClick(bool i_Correct)
        {
            if (!i_Correct)
            {
                m_Game.ForceRevealBoardGuessState(true);
                updateCellsBoardAfterClick();
                System.Threading.Thread.Sleep(800);
                m_Game.ForceRevealBoardGuessState(false);
            }

            updateCellsBoardAfterClick(i_Correct);

            if (m_Game.IsNewTurn())
            {
                m_Game.ClearTurn(i_Correct);
                updateLabels();
            }

            updateCellsBoardAfterClick();
        }

        private void updateCellsBoardAfterClick(bool i_Correct = false)
        {
            for (int i = 0; i < tableLayoutPanelBoard.RowCount; i++)
            {
                for (int j = 0; j < tableLayoutPanelBoard.ColumnCount; j++)
                {
                    Control crl = tableLayoutPanelBoard.GetControlFromPosition(j, i);
                    crl.Text = m_Game.GetCellValue(i, j);
                    (crl as CellButton).InCheck = m_Game.IsCellInCheck((crl as CellButton).RowIndex, (crl as CellButton).ColumnIndex);

                    if (m_Game.GetCellPlayer(i, j) != -1)
                    {
                        crl.BackColor = sr_PairsColor[m_Game.GetCellPlayer(i, j)];
                        crl.Enabled = false;
                    }
                    else if ((crl as CellButton).InCheck && !m_Game.IsNewTurn())
                    {
                        crl.Enabled = false;
                        crl.BackColor = sr_PairsColor[m_Game.CurrentPlayerIndex()];
                        crl.ForeColor = sr_DefaultBoardButtonForeColor;
                    }
                    else
                    {
                        crl.BackColor = sr_DefaultBoardButtonBackColor;
                        crl.Enabled = true;
                    }
                }
            }

            if (m_Game.IsTurnOver() && !i_Correct)
            {
                if (m_Game.IsGuessesInit())
                {
                    tableLayoutPanelBoard.GetControlFromPosition(m_Game.GetColumnGuess(0), m_Game.GetRowGuess(0)).BackColor = sr_WrongBoardButtonForeColor;
                    tableLayoutPanelBoard.GetControlFromPosition(m_Game.GetColumnGuess(1), m_Game.GetRowGuess(1)).BackColor = sr_WrongBoardButtonForeColor;
                }
            }

            Refresh();
        }
        private void updateLabels()
        {
            labelCurrentPlayer.Text = Messages.CurrentPlayerLabelText(m_Game.GetPlayerName(m_Game.CurrentPlayerIndex()));
            labelCurrentPlayer.BackColor = sr_PairsColor[m_Game.CurrentPlayerIndex()];
            labelFirstScore.Text = Messages.FirstPlayerLabelText(m_Game.GetPlayerScore(0));
            labelSecondScore.Text = Messages.SecondPlayerLabelText(m_Game.GetPlayerScore(1));
            Refresh();
        }

        private void showFinishMessage()
        {
            string winner = m_Game.CurrentWinnerName();
            DialogResult dialogResult = MessageBox.Show(Messages.FinishMessageBoxText(winner),
                Messages.k_FinishMessageBoxTitle, MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.No)
            {
                m_WantToPlay = false;
            }
        }

        private void notifyNoLegalConfiguration()
        {
            disableAllControls(this);
            Label notification = new Label();
            notification.Text = Messages.k_NoLegalConfiguration;
            notification.Visible = true;
            notification.BackColor = Color.White;
            notification.ForeColor = Color.Black;
            notification.Left = 50;
            notification.Top = tableLayoutPanelBoard.Height + 50;
            notification.Font = new Font(this.Font.FontFamily, this.Font.Size, FontStyle.Bold);
            notification.AutoSize = true;
            notification.Name = "label";
            Controls.Add(notification);
            notification.BringToFront();
            Refresh();
        }
        private void disableAllControls(Control i_Control)
        {
            foreach (Control crl in i_Control.Controls)
            {
                crl.Enabled = false;
                crl.SendToBack();
                disableAllControls(crl);
            }
        }
    }
}
