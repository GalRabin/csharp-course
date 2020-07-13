using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameUI
{
    class CellButton : Button
    {
        private int m_RowIndex;
        private int m_ColumnIndex;
        private bool m_IsInCheck = false;
        private string m_value;

        public CellButton(int i_RowIndex, int i_ColumnIndex)
        {
            this.m_RowIndex = i_RowIndex;
            this.m_ColumnIndex = i_ColumnIndex;
        }

        public int RowIndex
        {
            get
            {
                return this.m_RowIndex;
            }
        }
        public int ColumnIndex
        {
            get
            {
                return this.m_ColumnIndex;
            }
        }
        
        public bool InCheck
        {
            get
            {
                return m_IsInCheck;
            }
            set
            {
                m_IsInCheck = value;
            }
        }

        public string Value
        {
            get
            {
                return m_value;
            }
            set
            {
                m_value = value;
            }
        }

        public virtual void ShowAndDisableValueInCheck(Color i_PlayerColor)
        {
            Text = Value;
            InCheck = true;
            BackColor = i_PlayerColor;
            Enabled = false;
        }

        public virtual void ShowAndDisableValue(Color i_PlayerColor)
        {
            Text = Value;
            InCheck = false;
            BackColor = i_PlayerColor;
            Enabled = false;
        }
        public virtual void ShowAsWrong(Color i_WrongColor)
        {
            Text = Value;
            InCheck = false;
            BackColor = i_WrongColor;
        }
        public virtual void ShowDefaultAndDisable(Color i_DefaultColor, string i_DefaultText)
        {
            BackColor = i_DefaultColor;
            Text = i_DefaultText;
            Enabled = false;
            InCheck = false;
        }
        public virtual void ShowDefault(Color i_DefaultColor, string i_DefaultText)
        {
            BackColor = i_DefaultColor;
            Text = i_DefaultText;
            Enabled = true;
            InCheck = false;
        }

    }
}
