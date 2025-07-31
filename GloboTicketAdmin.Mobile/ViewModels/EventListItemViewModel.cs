using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloboTicketAdmin.Mobile.ViewModels
{
    public partial class EventListItemViewModel : ObservableObject
    {
        [ObservableProperty]
        private Guid _id;

        [ObservableProperty]
        private string? _imageUrl;

        [ObservableProperty]
        private string _name;

        [ObservableProperty]
        private double _price;

        [ObservableProperty]
        private DateTime _date;

        [ObservableProperty]
        private EventStatusEnum _eventStatus;

        [ObservableProperty]
        private List<string> _artists;

        [ObservableProperty]
        private CategoryViewModel? _category;

        public EventListItemViewModel(
            Guid id,
            string name,
            double price,
            DateTime date,
            List<string> artists,
            EventStatusEnum status,
            string? imageUrl = null,
            CategoryViewModel? category = null)
        {
            _id = id;
            _imageUrl = imageUrl;
            _name = name;
            _price = price;
            _date = date;
            _artists = artists;
            _eventStatus = status;
            _category = category;
        }
    }
}
