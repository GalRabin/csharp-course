﻿using GameLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
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
        private int m_BoardRows = 4;
        private int m_BoardColumns = 4;
        private int m_ButtonsWidth;
        private int m_ButtonsHeight;
        private bool m_LoginFormClosedByX = false;
        private bool m_WantToPlay = true;
        private Dictionary<string, object> m_CharImageDict;
        private bool m_HasInternetConnection;


        public FormGame()
        {
            m_Game = new GameLogic.GameManager();
            checkInternetConnection();

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
            setCellButtonsBoard();
            Refresh();

            if (m_Game.isComputerTurn)
            {
                computerPlay();
            }
        }
        private void createTable()
        {
            tableLayoutPanelBoard.ColumnCount = m_BoardColumns;
            tableLayoutPanelBoard.RowCount = m_BoardRows;
            int rowPercentage = 100 / m_BoardRows;
            int columnPercentage = 100 / m_BoardColumns;

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
            m_ButtonsWidth = tableLayoutPanelBoard.Width / m_BoardColumns;
            m_ButtonsHeight = tableLayoutPanelBoard.Height / m_BoardRows;
            generateCharImageDict(m_Game.GetRandomObjects());
            CellButton cellButton = null;

            for (int i = 0; i < tableLayoutPanelBoard.RowCount; i++)
            {
                for (int j = 0; j < tableLayoutPanelBoard.ColumnCount; j++)
                {
                    if (m_HasInternetConnection)
                    {
                        cellButton = new ImageCellButton(i, j, (PictureBox)m_CharImageDict[m_Game.GetCellValue(i, j, true)]);
                        cellButton = createCellButton(ref cellButton);
                        tableLayoutPanelBoard.Controls.Add(cellButton, j, i);
                    }
                    else
                    {
                        cellButton = new CellButton(i, j);
                        cellButton = createCellButton(ref cellButton);
                        tableLayoutPanelBoard.Controls.Add(cellButton, j, i);
                    }
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
        private CellButton createCellButton(ref CellButton io_CellButton)
        {
            io_CellButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));
            io_CellButton.Location = new System.Drawing.Point(3, 3);
            io_CellButton.Name = string.Format("Button {0}, {1}", io_CellButton.RowIndex, io_CellButton.ColumnIndex);
            io_CellButton.Size = new System.Drawing.Size(m_ButtonsWidth, m_ButtonsHeight);
            io_CellButton.TabIndex = tableLayoutPanelBoard.TabIndex + io_CellButton.RowIndex + io_CellButton.ColumnIndex;
            io_CellButton.Text = "";
            io_CellButton.BackColor = sr_DefaultBoardButtonBackColor;
            io_CellButton.ForeColor = sr_DefaultBoardButtonForeColor;
            io_CellButton.UseVisualStyleBackColor = true;
            io_CellButton.Value = m_Game.GetCellValue(io_CellButton.RowIndex, io_CellButton.ColumnIndex, true);
            io_CellButton.Click += new EventHandler(cellButton_Click);

            return io_CellButton;
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
                            m_BoardRows = win.BoardHeight;
                            m_BoardColumns = win.BoardWidth;
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
                        m_BoardRows = win.BoardHeight;
                        m_BoardColumns = win.BoardWidth;
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
                bool correct = false;
                if (!m_Game.IsGuessesInit())
                {
                    correct = m_Game.SetGuess((sender as CellButton).RowIndex, (sender as CellButton).ColumnIndex);
                    (sender as CellButton).InCheck = m_Game.IsCellInCheck((sender as CellButton).RowIndex, (sender as CellButton).ColumnIndex);
                    handleFirstClick();
                }
                else
                {
                    correct = m_Game.SetGuess((sender as CellButton).RowIndex, (sender as CellButton).ColumnIndex);
                    (sender as CellButton).InCheck = m_Game.IsCellInCheck((sender as CellButton).RowIndex, (sender as CellButton).ColumnIndex);
                    handleSecondClick(correct);

                    if (m_Game.IsNewTurn())
                    {
                        m_Game.ClearTurn(correct);
                        updateLabels();
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
        }

        private void handleGameOver()
        {
            showFinishMessage();

            if (m_WantToPlay)
            {
                m_Game.ResetGame();
                generateCharImageDict(m_Game.GetRandomObjects());
                setCellButtonsBoard();
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
            handleFirstClick();
            correct = m_Game.SetGuess();
            handleSecondClick(correct);

            if (m_Game.IsNewTurn())
            {
                m_Game.ClearTurn(correct);
                updateLabels();
            }
        }

        private void handleFirstClick()
        {
            Control crl = tableLayoutPanelBoard.GetControlFromPosition(m_Game.GetColumnGuess(0), m_Game.GetRowGuess(0));
            (crl as CellButton).ShowAndDisableValueInCheck(sr_PairsColor[m_Game.CurrentPlayerIndex()]);
            Refresh();
            System.Threading.Thread.Sleep(800);
            (crl as CellButton).ShowDefaultAndDisable(sr_DefaultBoardButtonBackColor, "");
            Refresh();
        }
        private void handleSecondClick(bool i_Correct)
        {
            Control crl = tableLayoutPanelBoard.GetControlFromPosition(m_Game.GetColumnGuess(1), m_Game.GetRowGuess(1));
            (crl as CellButton).ShowAndDisableValueInCheck(sr_PairsColor[m_Game.CurrentPlayerIndex()]);
            Refresh();
            System.Threading.Thread.Sleep(800);

            if (i_Correct)
            {
                handleSuccessGuess(m_Game.GetCellPlayer(m_Game.GetRowGuess(1), m_Game.GetColumnGuess(1)));
            }
            else
            {
                handleFailGuess();
            }

            Refresh();
        }
        private void handleSuccessGuess(int i_PlayerIndex)
        {
            Control firstGuess = tableLayoutPanelBoard.GetControlFromPosition(m_Game.GetColumnGuess(0), m_Game.GetRowGuess(0));
            Control secondGuess = tableLayoutPanelBoard.GetControlFromPosition(m_Game.GetColumnGuess(1), m_Game.GetRowGuess(1));
            (firstGuess as CellButton).ShowAndDisableValue(sr_PairsColor[i_PlayerIndex]);
            (secondGuess as CellButton).ShowAndDisableValue(sr_PairsColor[i_PlayerIndex]);
        }

        private void handleFailGuess()
        {
            Control firstGuess = tableLayoutPanelBoard.GetControlFromPosition(m_Game.GetColumnGuess(0), m_Game.GetRowGuess(0));
            Control secondGuess = tableLayoutPanelBoard.GetControlFromPosition(m_Game.GetColumnGuess(1), m_Game.GetRowGuess(1));
            (firstGuess as CellButton).ShowAsWrong(sr_WrongBoardButtonForeColor);
            (secondGuess as CellButton).ShowAsWrong(sr_WrongBoardButtonForeColor);
            Refresh();
            System.Threading.Thread.Sleep(800);
            (firstGuess as CellButton).ShowDefault(sr_DefaultBoardButtonBackColor, "");
            (secondGuess as CellButton).ShowDefault(sr_DefaultBoardButtonBackColor, "");
            Refresh();
        }
        private void setCellButtonsBoard()
        {
            for (int i = 0; i < tableLayoutPanelBoard.RowCount; i++)
            {
                for (int j = 0; j < tableLayoutPanelBoard.ColumnCount; j++)
                {
                    Control crl = tableLayoutPanelBoard.GetControlFromPosition(j, i);
                    (crl as CellButton).ShowDefault(sr_DefaultBoardButtonBackColor, m_Game.GetCellValue(i, j));
                    (crl as CellButton).Value = m_Game.GetCellValue(i, j, true);
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
            notification.Location = new Point(this.Width / 3,
                tableLayoutPanelBoard.Top + tableLayoutPanelBoard.Height + 20);
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

        private void generateCharImageDict(List<string> i_RandomObjects)
        {
            m_CharImageDict = new Dictionary<string, object>();

            foreach (string str in i_RandomObjects)
            {
                if (m_HasInternetConnection)
                {
                    m_CharImageDict.Add(str, generateImage(m_ButtonsWidth, m_ButtonsHeight));
                }
                else
                {
                    m_CharImageDict.Add(str, str);
                }
            }
        }
        private PictureBox generateImage(int i_width, int i_Height)
        {
            PictureBox pictureBox = new PictureBox();
            pictureBox.Size = new Size(i_width, i_Height);
            pictureBox.Load("https://picsum.photos/" + i_width + "/" + i_Height);

            return pictureBox;
        }

        private void checkInternetConnection()
        {
            try
            {
                Ping myPing = new Ping();
                String host = "google.com";
                byte[] buffer = new byte[32];
                int timeout = 1000;
                PingOptions pingOptions = new PingOptions();
                PingReply reply = myPing.Send(host, timeout, buffer, pingOptions);
                m_HasInternetConnection = (reply.Status == IPStatus.Success);
            }
            catch (Exception)
            {
                m_HasInternetConnection = false;
            }
        }
    }
}
