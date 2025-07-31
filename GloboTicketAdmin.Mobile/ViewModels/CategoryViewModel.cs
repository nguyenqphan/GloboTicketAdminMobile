using System;
using CommunityToolkit.Mvvm.ComponentModel;

namespace GloboTicketAdmin.Mobile.ViewModels
{
    public partial class CategoryViewModel : ObservableObject
    {
        [ObservableProperty]
        private Guid id;

        [ObservableProperty]
        private string name = default!;
    }
}
