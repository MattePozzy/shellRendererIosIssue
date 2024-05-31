using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace MauiApp12
{
    public partial class BaseViewModel : ObservableObject
    {
        [ObservableProperty]
        private string titoloPagina = "";

        public string _titoloPaginaOriginale = "";

        public BasePage PaginaCollegata;

    }

    public partial class MainPageViewModel : BaseViewModel
    {
        [ObservableProperty]
        private bool _isBusy = false;

        [RelayCommand]
        private async Task GoToSecond()
        {
            IsBusy = true;
            CreateMenu();

            // simulate task
            await Task.Delay(500);
            await Shell.Current.GoToAsync("//SecondPage");
            IsBusy = false;
        }

        private void CreateMenu()
        {
            List<ShellItem> menu = [
                  new ShellContent
                    {
                        //FlyoutIcon = ,
                        Title = "second page",
                        ContentTemplate = new DataTemplate(typeof(SecondPage)),
                        Route = "SecondPage"
                    },
                    new MenuItem
                    {
                        Text = "logout",
                        //IconImageSource = BaseMenu.IconaMenu(MaterialFontIcons.ExitToApp, IconColor),
                        Command = new Command(() =>
                        {                          
                            // Matteo 20230908 - se uso GoToAsync non viene cambiato l'elemento selezionato nel menù che resta su logout.
                            //Shell.Current.CurrentItem = Shell.Current.Items[0];
                            Application.Current.MainPage = new AppShell();
                        })
                    },
                ];

            foreach (ShellItem item in menu)
            {
                Shell.Current.Items.Add(item);
            }
        }

    }

    public partial class SecondPageViewModel : BaseViewModel
    {
        public SecondPageViewModel()
        {
            ColonnaCentrale = new GridLength(0.4, GridUnitType.Star);


            ListaOrariInseriti = new ObservableCollection<string> { "A", "B", "C" };

            PaginaCaricta = true;
            TitoloPagina = "Pippo page";
        }

        [ObservableProperty]
        private ObservableCollection<string> _ListaOrariInseriti;

        [ObservableProperty]
        private bool _paginaCaricta = false;

        [ObservableProperty]
        private double _tabSel = 0;

        [RelayCommand]
        private void ApriModificaData()
        {
            //PaginaCollegata.RipristinaTitolo();
#if ANDROID
            MainActivity.ChageToolbar(MaterialFontIcons.Menu, Colors.White);
#endif

#if IOS
            AppDelegate.ChageToolbar(MaterialFontIcons.Menu, Colors.White);
#endif
        }

        [RelayCommand]
        private void ApriModificaTimeZoneManuale() { }

        [RelayCommand]
        private void Test()
        {
#if ANDROID
            MainActivity.ChageToolbar(MaterialFontIcons.MessageBadgeOutline, Colors.Red);
#endif

#if IOS
            AppDelegate.ChageToolbar(MaterialFontIcons.MessageBadgeOutline, Colors.Red);
#endif

            //Label lblTitolo = PaginaCollegata.GetLblTitolo();
            //lblTitolo.FontFamily = "FontIcone";
            //lblTitolo.Text = $"{_titoloPaginaOriginale} {MaterialFontIcons.FaceAgent}";
            //lblTitolo.TextColor = Colors.Red;
        }

        [ObservableProperty]
        private GridLength _colonnaCentrale;

        [RelayCommand]
        private async Task TabSelChanged(double indx)
        {
            if (indx == 1)
            {
                // Lista
                //ShowLoading();
                //await Task.Delay(200);

                //BtnAddVisibile = false;

                //IconeHeader = new VolosButton()
                //{
                //    BackgroundColor = Colors.Transparent,
                //    FontFamily = "FontIcone",
                //    Text = MaterialFontIcons.Filter,
                //    Command = ApriFiltroCommand,
                //    WidthRequest = 50,
                //    FontSize = FontSize.Medium
                //};

                //CancellaOrariVecchi(true);

                //List<Orari> lista = LibInit.SerializzaService.GetListaSerializzati<Orari>(false, $"{NomeOggettoFile}_");
                //lista = [.. lista.OrderBy(x => x.DataOrario)];

                //ListaOrariInseriti = new(lista);
                //ListaOrariCompleta = new(ListaOrariInseriti);

                //switch (TipoFiltro)
                //{
                //    case FiltraLista.Oggi:
                //        FiltraOggi();
                //        break;
                //    case FiltraLista.Futuro:
                //        FiltraFuturo();
                //        break;
                //    case FiltraLista.Passato:
                //        FiltraSettimana();
                //        break;
                //}

                //HideLoading();
            }
            else
            {
                //// Inserimento
                //if (GuidOrarioSel != default)
                //{
                //    bool ok = await VolosPopup.ApriConfirm(TS.Translate("AppMobileComuni.sostituireOrari"));
                //    if (ok)
                //    {
                //        Dati = ListaOrariCompleta.Find(x => x.Chiave == GuidOrarioSel);
                //        AggiornaLabels();
                //        GuidOrarioSel = default;
                //    }
                //}

                //IconeHeader = null;
                //BtnAddVisibile = true;

                //if (!string.IsNullOrEmpty(Dati.TimeZone_Cod))
                //{
                //    TitoloPagina = $"{TS.Translate("AppMobileComuni.orari")} {Dati.TimeZone_Descr}";
                //}
                //else
                //{
                //    TitoloPagina = $"{TS.Translate("AppMobileComuni.orari")} {GetUtenteTimezone().Valore}";
                //}

                //HideLoading();
            }
        }
    }

    public partial class ShellViewModel : BaseViewModel
    {
        [ObservableProperty]
        private Color _color = Colors.White;

        [ObservableProperty]
        private string _glyph = MaterialFontIcons.Alert;

        public ShellViewModel()
        {
            Color = Colors.White;
            Glyph = MaterialFontIcons.Alert;
        }
    }
}
