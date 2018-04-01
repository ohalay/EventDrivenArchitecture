using System;

namespace EventDrivenArchitecture.SSE.SSE
{
    public interface ISseClentService
    {
        Guid AddClient(SseCleint client);
        void RemoveClient(Guid clientId);
    }
}
