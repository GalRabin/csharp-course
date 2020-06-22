namespace Ex04.Menus.Delegates.Options
{
    public abstract class Option
    {
        protected readonly Option r_Parent;
        protected readonly string r_OptionHeader;

        protected Option(string i_OptionHeader, Option i_Parent = null)
        {
            r_Parent = i_Parent;
            r_OptionHeader = i_OptionHeader;
        }

        public string OptionHeader
        {
            get
            {
                return r_OptionHeader;
            }
        }

        public abstract void RunOption();
    }
}