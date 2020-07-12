using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameUI
{
    class CellButton : Button
    {
        public event EventHandler cellReveal;

        private int m_RowIndex;
        private int m_ColumnIndex;
        private bool m_IsReveal = false;
        private bool m_IsInCheck = false;

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
        public void changeReveal()
        {
            m_IsReveal = (this.m_IsReveal == false ? true : false);
            OnCellRevealed(EventArgs.Empty);
        }
        protected virtual void OnCellRevealed(EventArgs e)
        {
            EventHandler handler = cellReveal;

            if (handler != null)
            {
                handler(this, e);
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
    }
}
