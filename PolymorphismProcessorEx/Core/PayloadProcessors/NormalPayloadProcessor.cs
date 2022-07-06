using PolymorphismProcessorEx.Models;

namespace PolymorphismProcessorEx.Core.PayloadProcessors
{
    public class NormalPayloadProcessor : PayloadProcessor
    {
        protected override Func<MessagePayload, bool>? DataSelector => p=>p.MessageType==MessageType.Info;
        protected override Task OnProcess(IEnumerable<MessagePayload> payloads)
        {
            Console.WriteLine(payloads.FirstOrDefault()!.Message);
            return Task.CompletedTask;
        }
    }
}
