using GloboTicketAdmin.Mobile.Views;

namespace GloboTicketAdmin.Mobile
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new EventOverviewPage();
        }
    }
}
