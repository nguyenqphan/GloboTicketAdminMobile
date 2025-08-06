using GloboTicketAdmin.Mobile.ViewModels;

namespace GloboTicketAdmin.Mobile.Views;

public partial class EventOverviewPage : ContentPage
{
	public EventOverviewPage(EventListOverviewViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}