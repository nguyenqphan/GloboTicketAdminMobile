using GloboTicketAdmin.Mobile.Models;
using GloboTicketAdmin.Mobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GloboTicketAdmin.Mobile.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public EventRepository(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<EventModel?> GetEvent(Guid id)
        {
            using HttpClient client = _httpClientFactory.CreateClient("GloboTicketAdminApiClient");
            try 
            {
                EventModel? @event= await client.GetFromJsonAsync<EventModel>(
                    $"events/{id}",
                    new JsonSerializerOptions(JsonSerializerDefaults.Web)
                    );
                return @event;
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                return null;
            }
        }

        public async Task<List<EventModel>> GetEvents()
        {
            using HttpClient client = _httpClientFactory.CreateClient("GloboTicketAdminApiClient");
            try 
            {
                List<EventModel>? events = await client.GetFromJsonAsync<List<EventModel>>(
                    $"events",
                    new JsonSerializerOptions(JsonSerializerDefaults.Web)
                    );

                return events ?? new List<EventModel>();
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                return new List<EventModel>();
            }
        }

        public async Task<bool> UpdateStatus(Guid id, EventStatusModel status)
        {
            using HttpClient client = _httpClientFactory.CreateClient("GloboTicketAdminApiClient");
            try
            {
                var json = JsonSerializer.Serialize(status);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PutAsync($"events/{id}/status", content);
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    // Optionally log the error or handle it as needed
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
