using GloboTicketAdmin.Mobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloboTicketAdmin.Mobile.Models
{
    public class EventModel
    {
        public Guid Id { get; set; }
        public string? ImageUrl { get; set; }
        public string Name { get; set; } = default!;
        public double Price { get; set; }
        public DateTime Date { get; set; }
        public List<string> Artists { get; set; } = new();
        public string? Description { get; set; }
        public EventStatusEnum EventStatus { get; set; }
        public CategoryModel? Category { get; set; }
    }
}
