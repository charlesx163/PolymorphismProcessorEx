using PolymorphismProcessorEx.Models;

namespace PolymorphismProcessorEx.Core
{
    public class PolymorphismProcessorExecutor : IJobExecutor
    {
        private readonly IPolymorphismProcessorWorker _polymorphismProcessorWorker;

        public PolymorphismProcessorExecutor(IPolymorphismProcessorWorker polymorphismProcessorWorker)
        {
            _polymorphismProcessorWorker = polymorphismProcessorWorker;
        }
        public async Task<int> Execute(CancellationToken token)
        {
            var payloads = new List<MessagePayload>
            {
                new MessagePayload{
                    Message = "Hello World",
                    MessageType=MessageType.Info
                },
                new MessagePayload{
                    Message = "Hello Error",
                    MessageType=MessageType.Error
                },
            };
            await _polymorphismProcessorWorker.Process(payloads);
            return await Task.FromResult(1);
        }
    }
}
