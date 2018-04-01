using Newtonsoft.Json;

namespace EventDrivenArchitecture.SSE.SSE
{
    public static class SseExtentions
    {
        public static string ToSseString<T>(this SseMessage<T> msg) where T : class
        {
            var msgString = new System.Text.StringBuilder();

            if (!string.IsNullOrWhiteSpace(msg.Id))
            {
                msgString.Append($"id: {msg.Id}\n");
            }

            if (!string.IsNullOrWhiteSpace(msg.Event))
            {
                msgString.Append($"event: {msg.Event}\n");
            }

            if (msg.Data != null)
            {
                msgString.Append($"data: {JsonConvert.SerializeObject(msg.Data)}\n");
            }
            else
            {
                throw new System.ArgumentNullException("Data");
            }

            msgString.Append("\n");

            return msgString.ToString();
        }
    }
}
