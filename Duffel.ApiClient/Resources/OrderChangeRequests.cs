using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Duffel.ApiClient.Converters;
using Duffel.ApiClient.Models.Requests;
using Duffel.ApiClient.Models.Responses;

namespace Duffel.ApiClient.Resources
{
    public class OrderChangeRequests
    {
        private readonly HttpClient _httpClient;

        public OrderChangeRequests(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<OrderChangeResponse> Create(OrderChangeRequest request)
        {
            var payload = OrderChangeConverter.Serialize(request);
            
            var result = await _httpClient.PostAsync($"air/order_change_requests",
                new StringContent(payload, Encoding.UTF8, "application/json"));
            
            return await SingleItemResponseConverter.GetAndDeserialize<OrderChangeResponse>(result);
        }

        public async Task<OrderChangeResponse> Get(string orderChangeRequestId)
        {
            var result = await _httpClient.GetAsync($"/air/order_change_requests/{orderChangeRequestId}");
            return await SingleItemResponseConverter.GetAndDeserialize<OrderChangeResponse>(result);
        }
    }
}