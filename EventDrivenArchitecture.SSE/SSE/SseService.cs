using Microsoft.Extensions.Logging;
using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading.Tasks;

namespace EventDrivenArchitecture.SSE.SSE
{
    public class SseService : ISseSendService, ISseClentService
    {
        private readonly ConcurrentDictionary<Guid, SseCleint> clients = new ConcurrentDictionary<Guid, SseCleint>();
        private readonly ILogger<SseService> logger;

        public SseService(ILoggerFactory loggerFactory)
        {
            this.logger = loggerFactory.CreateLogger<SseService>();
        }


        public Guid AddClient(SseCleint client)
        {
            Guid clientId = Guid.NewGuid();

            if (clients.TryAdd(clientId, client))
            {
                this.logger.LogError("Can't add new client");
            }

            return clientId;
        }

        public void RemoveClient(Guid clientId)
        {
            if (clients.TryRemove(clientId, out _))
            {
                this.logger.LogError("Can't remove old client");
            }
        }

        public async Task SendMessageAsync<T>(SseMessage<T> message) where T : class
        {
            var tasks = this.clients.Values
                .ToList()
                .Select(client => client.SendMessageAsync(message));

            await Task.WhenAll(tasks);
        }
    }
}