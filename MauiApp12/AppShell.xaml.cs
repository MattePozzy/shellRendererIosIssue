namespace MauiApp12
{
    public partial class AppShell : Shell
    {
        private static AppShell Me;

        public AppShell()
        {
            InitializeComponent();
            Me = this;
        }

        public void CambiaIconaMenu(string icona, Color color)
        {
            var page = Shell.Current.CurrentPage;
            if (page != null && page.BindingContext is BaseViewModel bv)
            {
                bv.TitoloPagina = "ci sono notifiche!";
            }

            //if (BindingContext is ShellViewModel vm)
            //{
            //    vm.Color = color;
            //    vm.Glyph = icona;
            //    OnPropertyChanged(nameof(vm.Color));
            //    OnPropertyChanged(nameof(vm.Glyph));
            //}
            //iconaMenu.Glyph = icona;
            //iconaMenu.Color = color;
        }

        #region GetInstance
        public static AppShell GetInstance()
        {
            if (Me == null) Me = new AppShell();
            return Me;
        }
        #endregion

    }
}
