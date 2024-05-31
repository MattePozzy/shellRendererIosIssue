namespace MauiApp12;

public partial class BasePage : ContentPage
{
    public BasePage()
    {
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        if (BindingContext is BaseViewModel bvm)
        {
            SetBinding(TitleProperty, new Binding(path: nameof(BaseViewModel.TitoloPagina), source: bvm));
            bvm.PaginaCollegata = this;
            bvm._titoloPaginaOriginale = LblTitolo.Text;
        }
    }

    public Label GetLblTitolo()
    {
        return LblTitolo;
    }

    public void RipristinaTitolo()
    {
        if (BindingContext is BaseViewModel bvm)
        {
            LblTitolo.Text = bvm._titoloPaginaOriginale;
            LblTitolo.TextColor = Colors.White;
        }
    }
}