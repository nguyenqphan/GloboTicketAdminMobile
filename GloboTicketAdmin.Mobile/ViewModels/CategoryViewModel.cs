
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GloboTicketAdmin.Mobile.ViewModels
{
    public class CategoryViewModel : INotifyPropertyChanged
    {
        private Guid _id;
        private string _name = default!;

        public Guid Id { 
            get => _id;
            set
            {
                if (!value.Equals(_id))
                { 
                    _id = value;
                    OnPropertyChanged();
                }
            } 
        }
        public string Name { 
            get => _name;
            set 
            {
                if (!value.Equals(_name))
                {
                    value = _name;
                    OnPropertyChanged();
                }
            } 
        }
        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
