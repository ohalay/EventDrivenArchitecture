using System;

namespace EventDrivenArchitecture.SSE.SSE
{
    public class SseMessage<T> where T: class
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string Event { get; set; }

        public T Data { get; set; }
    }
}