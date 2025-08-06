using GloboTicketAdmin.Mobile.Models;
using GloboTicketAdmin.Mobile.Repositories;
using GloboTicketAdmin.Mobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloboTicketAdmin.Mobile.Services
{
    public class EventService : IEventService
    {
        private readonly IEventRepository _eventRepository;

        public EventService(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        async Task<EventModel?> IEventService.GetEvent(Guid id)
        {
            return await _eventRepository.GetEvent(id);
        }

        async Task<List<EventModel>> IEventService.GetEvents()
        {
            return await _eventRepository.GetEvents();
        }

        async Task<bool> IEventService.UpdateStatus(Guid id, EventStatusModel status)
        {
            return await _eventRepository.UpdateStatus(id, status);
        }
    }
}
