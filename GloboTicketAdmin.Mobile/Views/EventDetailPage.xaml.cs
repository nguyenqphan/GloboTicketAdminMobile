using GloboTicketAdmin.Mobile.ViewModels;

namespace GloboTicketAdmin.Mobile.Views;

public partial class EventDetailPage : ContentPage
{
    public EventDetailPage()
    {
        InitializeComponent();
        BindingContext = new EventDetailViewModel();
    }

   
}