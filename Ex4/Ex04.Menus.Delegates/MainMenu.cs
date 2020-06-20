using Ex04.Menus.Delegates.Options;

namespace Ex04.Menus.Delegates
{
    public class MainMenu
    {
        private readonly string r_MainMenuHeader;
        private readonly OptionMenuHandler r_MainMenuHandler;

        public MainMenu(string i_MainMenuHeader)
        {
            r_MainMenuHeader = i_MainMenuHeader;
            r_MainMenuHandler = new OptionMenuHandler(i_MainMenuHeader);
        }

        public OptionMenuHandler MainMenuHandler
        {
            get
            {
                return r_MainMenuHandler;
            }
        }

        public void AddMenuOption(Option i_Option)
        {
            r_MainMenuHandler.AddMenuOption(i_Option);
        }

        public void RemoveMenuOption(Option i_Option)
        {
            r_MainMenuHandler.RemoveMenuOption(i_Option);
        }

        public void Show()
        {
            r_MainMenuHandler.RunOption();
        }
    }
}