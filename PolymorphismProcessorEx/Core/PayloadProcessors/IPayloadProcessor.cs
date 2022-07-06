using PolymorphismProcessorEx.Models;

namespace PolymorphismProcessorEx.Core.PayloadProcessors
{
    public interface IPayloadProcessor
    {
        Task Process(IEnumerable<MessagePayload> payloads);
    }
}
