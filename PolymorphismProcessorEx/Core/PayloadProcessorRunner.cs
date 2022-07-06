using PolymorphismProcessorEx.Core.PayloadProcessors;
using PolymorphismProcessorEx.Models;

namespace PolymorphismProcessorEx.Core
{
    public interface IPayloadProcessorRunner 
    {
        Task Run(IEnumerable<MessagePayload> payloads);
    }

    public class PayloadProcessorRunner : IPayloadProcessorRunner
    {
        private readonly IEnumerable<IPayloadProcessor> _processors;
        public PayloadProcessorRunner(IEnumerable<IPayloadProcessor> processors)
        {
            _processors = processors;
        }
        public async Task Run(IEnumerable<MessagePayload> payloads)
        {
            foreach (var processor in _processors)
            {
                await processor.Process(payloads);
            }
        }
    }
}
