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
        private GameLogic.GameManager m_Game;
        private int m_BoardHeight = 4;
        private int m_BoardWidth = 4;
        /*private int m_RowGuess;
        private int m_ColumnGuess;*/
        public FormGame()
        {
            m_Game = new GameLogic.GameManager();
            while(!ensureValidConfiguration());
            InitializeComponent();
            InitialBoard();
        }

        private void InitialBoard()
        {
            this.tableLayoutPanelBoard.ColumnCount = this.m_BoardWidth;
            this.tableLayoutPanelBoard.RowCount = this.m_BoardHeight;

            for (int i = 0; i < this.tableLayoutPanelBoard.ColumnCount; i++)
            {
                this.tableLayoutPanelBoard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            }
            for (int i = 0; i < this.tableLayoutPanelBoard.RowCount; i++)
            {
                this.tableLayoutPanelBoard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            }
            for (int i = 0; i < this.tableLayoutPanelBoard.ColumnCount; i++)
            {
                for (int j = 0; j < this.tableLayoutPanelBoard.RowCount; j++)
                {
                    CellButton cellButton = new CellButton(i, j);
                    cellButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
                    cellButton.Location = new System.Drawing.Point(3, 3);
                    cellButton.Name = string.Format("Button {0}, {1}", i, j);
                    cellButton.Size = new System.Drawing.Size(110, 78);
                    cellButton.TabIndex = this.tableLayoutPanelBoard.TabIndex + i + j;
                    cellButton.Text = "";
                    cellButton.UseVisualStyleBackColor = true;
                    cellButton.Click += new System.EventHandler(this.cellButton_Click);
                    this.tableLayoutPanelBoard.Controls.Add(cellButton, i, j);
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


        private void cellButton_Click(object sender, EventArgs e)
        {
            bool correct = this.m_Game.SetGuess((sender as CellButton).RowIndex, (sender as CellButton).ColumnIndex);
            (sender as CellButton).Text = this.m_Game.StringBoard[(sender as CellButton).ColumnIndex, (sender as CellButton).RowIndex];
            System.Threading.Thread.Sleep(1000);
            
            // I stopped here



            if (!correct)
            {
                (sender as CellButton).Text = "";
            }
        }

        private void tableLayoutPanelBoard_Paint(object sender, PaintEventArgs e)
        {
            TableLayoutPanel table = (sender as TableLayoutPanel);
            //table.BackColor = Color.Black;
            table.ColumnCount = this.m_BoardWidth;
            table.RowCount = this.m_BoardHeight;

            for (int i = 0; i < this.tableLayoutPanelBoard.ColumnCount; i++)
            {
                table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            }
            for (int i = 0; i < this.tableLayoutPanelBoard.RowCount; i++)
            {
                table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            }
        }
    }
}
