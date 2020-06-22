namespace Ex04.Menus.Interfaces.Options
{
    public class OptionCallback : Option
    {
        private readonly ICallback r_Callback;

        public OptionCallback(ICallback i_Callback, string i_OptionHeader, Option i_Parent = null) : base(i_OptionHeader, i_Parent)
        {
            r_Callback = i_Callback;
        }

        public override void RunOption()
        {
            r_Callback.RunCallback();
            Utils.PressAnyKeyToContinue();
            r_Parent.RunOption();
        }
    }
}