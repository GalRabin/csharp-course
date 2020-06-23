namespace Ex04.Menus.Delegates.Options
{
    public delegate void UserCommandNotificationDelegate();

    public class OptionCallback : Option
    {
        public event UserCommandNotificationDelegate UserCommandChoice;
        
        public OptionCallback(UserCommandNotificationDelegate i_UserCommandCallback, string i_OptionHeader, Option i_Parent = null) : base(i_OptionHeader, i_Parent)
        {
            UserCommandChoice += i_UserCommandCallback;
        }

        public override void RunOption()
        {
            if (UserCommandChoice != null)
            {
                UserCommandChoice.Invoke();
            }

            Utils.PressAnyKeyToContinue();
            r_Parent.RunOption();
        }
    }
}