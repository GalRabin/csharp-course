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
        private bool m_ValidConfiguration = false;
        private GameLogic.LogicManager m_Game;
        private int m_BoardHeight = 4;
        private int m_BoardWidth = 4;
        private int m_RowGuess;
        private int m_ColumnGuess;
        public FormGame()
        {
            m_Game = new GameLogic.LogicManager();
            while(ensureValidConfiguration());
            InitializeComponent();
            startGame();
        }

        private void startGame()
        {
            while(!m_Game.IsGameFinished())
            {
                if (m_Game.isComputerTurn)
                {
                    m_Game.SetGuess();
                }
                else
                {
                    
                    m_Game.SetGuess(this.m_RowGuess, this.m_ColumnGuess);
                }
            }
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
