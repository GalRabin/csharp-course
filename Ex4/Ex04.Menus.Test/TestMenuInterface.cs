using Ex04.Menus.Interfaces;
using Ex04.Menus.Interfaces.Options;
using Ex04.Menus.Test.Commands;

namespace Ex04.Menus.Test
{ 
    public class TestMenuInterface
    {
        private readonly MainMenu r_MainMenu;

        public TestMenuInterface()
        {
            r_MainMenu = new MainMenu("Main Menu");
            InitializeFirstSubMenu();
            InitializeSecondSubMenu();
            r_MainMenu.Show();
        }

        private void InitializeFirstSubMenu()
        {
            OptionMenuHandler subMenu = new OptionMenuHandler("Version and Capitals", r_MainMenu.MainMenuHandler);
            subMenu.AddMenuOption(new OptionCallback(new CountCapitals(), "Count Capitals", subMenu));
            subMenu.AddMenuOption(new OptionCallback(new ShowVersion(),"Show Version", subMenu));
            r_MainMenu.AddMenuOption(subMenu);
        }
        
        private void InitializeSecondSubMenu()
        {
            OptionMenuHandler subMenu = new OptionMenuHandler("Show Date/Time", r_MainMenu.MainMenuHandler);
            subMenu.AddMenuOption(new OptionCallback(new ShowTime(), "Show Time", subMenu));
            subMenu.AddMenuOption(new OptionCallback(new ShowDate(), "Show Date", subMenu));
            r_MainMenu.AddMenuOption(subMenu);
        }
    }
}