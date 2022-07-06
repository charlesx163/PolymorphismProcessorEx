using PolymorphismProcessorEx.Models;

namespace PolymorphismProcessorEx.Core
{
    public interface IPolymorphismProcessorWorker
    {
        Task Process(IEnumerable<MessagePayload> payloads);
    }

    public class PolymorphismProcessorWorker : IPolymorphismProcessorWorker
    {
        private readonly IPayloadProcessorRunner _runner;

        public PolymorphismProcessorWorker(IPayloadProcessorRunner runner)
        {
            _runner = runner;
        }
        public async Task Process(IEnumerable<MessagePayload> payloads)
        {
            await _runner.Run(payloads);
        }
    }
}
