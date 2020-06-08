using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex2
{
    public class CellGuess
    {
        private int m_RowIndex;
        private int m_ColumnIndex;

        public CellGuess(int i_RowIndex = -1, int i_ColumnIndex = -1)
        {
            this.m_RowIndex = i_RowIndex;
            this.m_ColumnIndex = i_ColumnIndex;
        }
     
        public bool Equals(CellGuess i_OtherGuess)
        {
            return this.m_RowIndex == i_OtherGuess.RowIndex && this.m_ColumnIndex == i_OtherGuess.ColumnIndex;
        }
        public int RowIndex
        {
            get
            {
                return this.m_RowIndex;
            }
            set
            {
                this.m_RowIndex = value;
            }
        }
        public int ColumnIndex
        {
            get
            {
                return this.m_ColumnIndex;
            }
            set
            {
                this.m_ColumnIndex = value;
            }
        }
    }
}