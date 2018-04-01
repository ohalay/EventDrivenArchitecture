using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Net.Http.Headers;

namespace EventDrivenArchitecture.SSE.SSE
{
    public class SseMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ISseClentService sseService;

        public SseMiddleware(RequestDelegate next, ISseClentService sseService)
        {
            this.next = next;
            this.sseService = sseService;
        }

        public async Task Invoke(HttpContext context)
        {
            const string eventStreamType = "text/event-stream";

            if (context.Request.Headers[HeaderNames.Accept] == eventStreamType)
            {
                context.Response.ContentType = eventStreamType;
                context.Response.Body.Flush();

                var client = new SseCleint(context.Response);
                Guid clientId = this.sseService.AddClient(client);

                context.RequestAborted.WaitHandle.WaitOne();

                sseService.RemoveClient(clientId);

                await Task.CompletedTask;
            }
            else
            {
                await this.next(context);
            }
        }
    }
}