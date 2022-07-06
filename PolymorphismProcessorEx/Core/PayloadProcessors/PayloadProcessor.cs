using PolymorphismProcessorEx.Models;

namespace PolymorphismProcessorEx.Core.PayloadProcessors
{
    public abstract class PayloadProcessor : IPayloadProcessor
    {
        protected virtual Func<MessagePayload, bool>? DataSelector => default;
        protected abstract Task OnProcess(IEnumerable<MessagePayload> payloads);

        public async Task Process(IEnumerable<MessagePayload> payloads)
        {
            var selectedPayloads = (DataSelector == null ? payloads : payloads.Where(DataSelector)).ToList();
            if (selectedPayloads.Count > 0)
            {
                await OnProcess(selectedPayloads);
            }
        }
        
    }
}
