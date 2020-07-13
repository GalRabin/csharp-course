using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameUI
{
    internal class ImageCellButton : CellButton
    {
        private PictureBox m_PictureBox;
        public ImageCellButton(int i_RowIndex, int i_ColumnIndex, PictureBox i_PictureBox) : base(i_RowIndex, i_ColumnIndex)
        {
            m_PictureBox = i_PictureBox;
        }
        public override void ShowAndDisableValueInCheck(Color i_PlayerColor)
        {
            InCheck = true;
            Enabled = false;
            BackgroundImage = m_PictureBox.Image;
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderColor = i_PlayerColor;
            FlatAppearance.BorderSize = 5;
        }
        public override void ShowAndDisableValue(Color i_PlayerColor)
        {
            InCheck = false;
            Enabled = false;
            BackgroundImage = m_PictureBox.Image;
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderColor = i_PlayerColor;
            FlatAppearance.BorderSize = 5;
        }

        public override void ShowAsWrong(Color i_WrongColor)
        {
            InCheck = false;
            BackgroundImage = m_PictureBox.Image;
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderColor = i_WrongColor;
            FlatAppearance.BorderSize = 5;
        }
        public override void ShowDefaultAndDisable(Color i_DefaultColor, string i_DefaultText)
        {
            base.ShowDefaultAndDisable(i_DefaultColor, i_DefaultText);
            BackgroundImage = null;
            BackColor = i_DefaultColor;
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderColor = Color.DarkGray;
            FlatAppearance.BorderSize = 3;
        }
        public override void ShowDefault(Color i_DefaultColor, string i_DefaultText)
        {
            base.ShowDefault(i_DefaultColor, i_DefaultText);
            BackgroundImage = null;
            BackColor = i_DefaultColor;
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderColor = Color.DarkGray;
            FlatAppearance.BorderSize = 3;
        }
    }
}
