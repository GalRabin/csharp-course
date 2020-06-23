using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Interfaces.Options
{
    public class OptionMenuHandler: Option
    {
        private readonly List<Option> r_Options;
        
        public OptionMenuHandler(string i_OptionHeader, Option i_Parent = null) : base(i_OptionHeader, i_Parent)
        {
            r_Options = new List<Option>();
        }
        
        public void AddMenuOption(Option i_Option)
        {
            r_Options.Add(i_Option);
        }
        
        public void RemoveMenuOption(Option i_Option)
        {
            r_Options.Remove(i_Option);
        }

        public override void RunOption()
        {
            Console.WriteLine(ToString());
            Console.Write(Messages.k_EnterUserChoice);
            int indexOption = Utils.GetValidInRangeFromUser(0, r_Options.Count);
            Console.Clear();

            if (indexOption == 0)
            {
                if (r_Parent != null)
                {
                    r_Parent.RunOption();    
                }
            }
            else
            {
                r_Options[indexOption - 1].RunOption();
            }
        }

        private string BackOrExitOption()
        {
            string option = "Exit";

            if (r_Parent != null)
            {
                option = "Back";
            }

            return option;
        }

        public override string ToString()
        {
            StringBuilder menu = new StringBuilder();
            string lineSeparator = new String('=', r_OptionHeader.Length);
            menu.AppendLine(lineSeparator);
            menu.AppendLine(r_OptionHeader);
            menu.AppendLine(lineSeparator);
            menu.AppendLine(string.Format("0 - {0}", BackOrExitOption()));

            for (int optionIndex = 0; optionIndex < r_Options.Count; optionIndex++)
            {
                menu.AppendLine(string.Format("{0} - {1}", optionIndex + 1, r_Options[optionIndex].OptionHeader));
            }

            return menu.ToString();
        }
    }
}