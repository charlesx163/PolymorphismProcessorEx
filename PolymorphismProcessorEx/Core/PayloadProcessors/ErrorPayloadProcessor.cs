using PolymorphismProcessorEx.Models;

namespace PolymorphismProcessorEx.Core.PayloadProcessors
{
    public class ErrorPayloadProcessor : PayloadProcessor
    {
        protected override Func<MessagePayload, bool>? DataSelector => p => p.MessageType == MessageType.Error;
        protected override Task OnProcess(IEnumerable<MessagePayload> payloads)
        {
            Console.WriteLine(payloads.FirstOrDefault()?.Message);
            return Task.CompletedTask;
        }
    }
}
