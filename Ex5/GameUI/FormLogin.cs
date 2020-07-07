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
    public partial class FormLogin : Form
    {
        private int m_CurrentHeight = 4;
        private int m_CurrentWidth = 4;
        private bool m_AgainstComputer = true;
        private bool m_ClosedByStart = false;
        
        public FormLogin()
        {
            InitializeComponent();
            this.ButtonBoardSize.Text = $"{m_CurrentHeight}x{m_CurrentWidth}";
            this.TextBoxSecondPlayerName.ReadOnly = true;
            this.ButtonAgainst.Text = "Against a Freind";
            this.TextBoxSecondPlayerName.Text = "- computer -";
        }

        public bool ClosedByStart
        {
            get
            {
                return m_ClosedByStart;
            }
        } 

        private void ButtonAgainst_Click(object sender, EventArgs e)
        {
            if (m_AgainstComputer)
            {
                this.ButtonAgainst.Text = "Against Computer";
                this.TextBoxSecondPlayerName.Text = "";
                this.TextBoxSecondPlayerName.ReadOnly = false;
                m_AgainstComputer = false;
            } else
            {
                this.ButtonAgainst.Text = "Against a Freind";
                this.TextBoxSecondPlayerName.Text = "- computer -";
                this.TextBoxSecondPlayerName.ReadOnly = true;
                m_AgainstComputer = true;
            }
        }


        private void ButtonBoardSize_Click(object sender, EventArgs e)
        {
            int newCurrentWidth = m_CurrentWidth < 6 ? m_CurrentWidth + 1 : 4;
            if (m_CurrentWidth > newCurrentWidth)
            {
                m_CurrentHeight = m_CurrentHeight < 6 ? m_CurrentHeight + 1 : 4;
            }
            m_CurrentWidth = newCurrentWidth;
            this.ButtonBoardSize.Text = $"{m_CurrentHeight}x{m_CurrentWidth}";
        }

        private void ButtonStart_Click(object sender, EventArgs e)
        {
            m_ClosedByStart = true;
        }
    }
}
