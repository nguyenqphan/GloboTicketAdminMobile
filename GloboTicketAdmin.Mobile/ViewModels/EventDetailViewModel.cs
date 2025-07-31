using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GloboTicketAdmin.Mobile.ViewModels
{
    public class EventDetailViewModel : INotifyPropertyChanged
    {
        private Guid _id;
        private string _name = default!;
        private double _price;
        private string _imageUrl = default!;
        private EventStatusEnum _eventStatus;
        private DateTime _date = DateTime.Now;
        private string _description = default!;
        private List<string> _artists = new List<string>();
        private CategoryViewModel _category = default!;

        public Guid Id
        {
            get => _id;
            set
            {
                if (!_id.Equals(value))
                {
                    _id = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Name
        {
            get => _name;
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged();
                }
            }
        }

        public double Price
        {
            get => _price;
            set
            {
                if (_price != value)
                {
                    _price = value;
                    OnPropertyChanged();
                }
            }
        }

        public string ImageUrl
        {
            get => _imageUrl;
            set
            {
                if (_imageUrl != value)
                {
                    _imageUrl = value;
                    OnPropertyChanged();
                }
            }
        }

        public EventStatusEnum EventStatus
        {
            get => _eventStatus;
            set
            {
                if (_eventStatus != value)
                {
                    _eventStatus = value;
                    OnPropertyChanged();
                    ((Command)CancelEventCommand).ChangeCanExecute();
                }
            }
        }

        public DateTime Date
        {
            get => _date;
            set
            {
                if (_date != value)
                {
                    _date = value;
                    OnPropertyChanged();
                    ((Command)CancelEventCommand).ChangeCanExecute();
                }
            }
        }

        public string Description
        {
            get => _description;
            set
            {
                if (_description != value)
                {
                    _description = value;
                    OnPropertyChanged();
                }
            }
        }

        public List<string> Artists
        {
            get => _artists;
            set
            {
                if (_artists != value)
                {
                    _artists = value;
                    OnPropertyChanged();
                }
            }
        }

        public CategoryViewModel Category
        {
            get => _category;
            set
            {
                if (_category != value)
                {
                    _category = value;
                    OnPropertyChanged();
                }
            }
        }

        private bool _showLargerImage;
        public bool ShowLargerImage
        {
            get => _showLargerImage;
            set
            {
                if (_showLargerImage != value)
                {
                    _showLargerImage = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(ShowThumbnailImage));
                }
            }
        }
        public bool ShowThumbnailImage => !ShowLargerImage;

        public ICommand CancelEventCommand { get; }

        private void CancelEvent()
        {
            EventStatus = EventStatusEnum.Canceled;
        }

        private bool CanCancelEvent() =>
            EventStatus != EventStatusEnum.Canceled && Date.AddHours(-4) > DateTime.Now;
        public EventDetailViewModel()
        {
            CancelEventCommand = new Command(CancelEvent, CanCancelEvent);

            Id = Guid.NewGuid();
            Name = "Nguyen";
            Price = 100.0;
            ImageUrl = "https://lindseybroospluralsight.blob.core.windows.net/globoticket/images/banjo.jpg";
            EventStatus = EventStatusEnum.Onsale;
            Date = DateTime.Now.AddMonths(6);
            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.";
            Artists = new List<string> { "Artist 1", "Artist 2", "Artist 3" };
            Category = new CategoryViewModel()
            {
                Id = Guid.NewGuid(),
                Name = "Music"
            };
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
