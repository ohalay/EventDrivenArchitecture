using System.Threading.Tasks;

namespace EventDrivenArchitecture.SSE.SSE
{
    public interface ISseSendService
    {
        Task SendMessageAsync<T>(SseMessage<T> message) where T: class;
    }
}