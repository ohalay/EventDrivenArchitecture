using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace EventDrivenArchitecture.SSE.SSE
{
    public class SseCleint
    {
        private readonly HttpResponse response;

        internal SseCleint(HttpResponse response)
        {
            this.response = response;
        }

        public async Task SendMessageAsync<T>(SseMessage<T> message) where T : class
        {
            await response.WriteAsync(message.ToSseString());

            response.Body.Flush();
        }
    }
}