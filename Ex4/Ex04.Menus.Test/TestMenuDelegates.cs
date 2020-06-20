using Ex04.Menus.Delegates;
using Ex04.Menus.Delegates.Options;
using Ex04.Menus.Test.Commands;

namespace Ex04.Menus.Test
{
    public class TestMenuDelegates
    {
        private readonly MainMenu r_MainMenu;

        public TestMenuDelegates()
        {
            r_MainMenu = new MainMenu("Main Menu");
            InitializeFirstSubMenu();
            InitializeSecondSubMenu();
            r_MainMenu.Show();
        }

        private void InitializeFirstSubMenu()
        {
            OptionMenuHandler subMenu = new OptionMenuHandler("Version and Capitals", r_MainMenu.MainMenuHandler);
            subMenu.AddMenuOption(new OptionCallback(CountCapitals.CountCapitalsFromUserInput, "Count Capitals", subMenu));
            subMenu.AddMenuOption(new OptionCallback(ShowVersion.PrintVersion, "Show Version", subMenu));
            r_MainMenu.AddMenuOption(subMenu);
        }

        private void InitializeSecondSubMenu()
        {
            OptionMenuHandler subMenu = new OptionMenuHandler("Show Date/Time", r_MainMenu.MainMenuHandler);
            subMenu.AddMenuOption(new OptionCallback(ShowTime.PrintTime, "Show Time", subMenu));
            subMenu.AddMenuOption(new OptionCallback(ShowDate.PrintDate, "Show Date", subMenu));
            r_MainMenu.AddMenuOption(subMenu);
        }
    }
}