using GloboTicketAdmin.Mobile.ViewModels;

namespace GloboTicketAdmin.Mobile.Views;

public partial class EventDetailPage : ContentPage
{
    public EventDetailPage(EventDetailViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }

   
}