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
        public FormGame()
        {
            m_Game = new GameLogic.GameManager();
            while(ensureValidConfiguration());
            InitializeComponent();
        }

        private bool ensureValidConfiguration()
        {
            if (!m_ValidConfiguration)
            {
                FormLogin win = new FormLogin();
                win.ShowDialog();
                if (win.ClosedByStart)
                {
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
