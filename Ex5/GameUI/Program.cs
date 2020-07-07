using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameUI
{
    class Program
    {
        public static void Main()
        {
            Application.EnableVisualStyles();
            FormGame formGame = new FormGame();
            formGame.ShowDialog();
        }
    }
}
