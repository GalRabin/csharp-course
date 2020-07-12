using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameUI
{
    class Messages
    {
        internal const string k_ArgumentExceptionNameLabelInLoginForm = 
            "Argument is not valid, Enter valid name (up to 20 English letters without special charachters)";
        internal const string k_FinishMessageBoxTitle = "Game Finished";
        internal const string k_NoLegalConfiguration = "No legal configuration set, exit and try again please.";
        internal static string CurrentPlayerLabelText(string i_CurrentPlayerName)
        {
            return string.Format("Current Player: {0}", i_CurrentPlayerName);
        }
        internal static string FirstPlayerLabelText(int i_FirstPlayerScore)
        {
            return string.Format("First Player Pairs: {0}", i_FirstPlayerScore);
        }
        internal static string SecondPlayerLabelText(int i_SecondPlayerScore)
        {
            return string.Format("Second Player Pairs: {0}", i_SecondPlayerScore);
        }

        internal static string FinishMessageBoxText(string i_WinnerName)
        {
            string msg = null;

            if (i_WinnerName != null)
            {
                msg = string.Format("The Winner is..." + Environment.NewLine +
                                        "{0}" + Environment.NewLine +
                                         "Would you like to play another match ? (Click 'No' for Exit) ", i_WinnerName);
            }
            else
            {
                msg = string.Format("Unfortunetly the game finished with draw." + Environment.NewLine +
                                         "Would you like to play another match ? (Click 'No' for Exit) ", i_WinnerName);
            }

            return msg;
        }
    }
}
