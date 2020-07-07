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
        private int m_RowIndex;
        private int m_ColumnIndex;

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

    }
}
