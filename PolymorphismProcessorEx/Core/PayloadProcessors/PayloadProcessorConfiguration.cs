using PolymorphismProcessorEx.Models;

namespace PolymorphismProcessorEx.Core.PayloadProcessors
{
    public class PayloadProcessorConfiguration
    {
        private readonly IList<IPayloadProcessor> _processors;
        private readonly PayloadProcessorFactory _factory;
        public PayloadProcessorConfiguration(PayloadProcessorFactory factory)
            
        {
            _factory = factory;
            _processors = new List<IPayloadProcessor>();
        }

        public PayloadProcessorConfiguration AddProcessor(MessageType type)
        {
            var processor= _factory(type);
            _processors.Add(processor!);
            return this;
        }
        public IPayloadProcessorRunner CreateRunner() => new PayloadProcessorRunner(_processors);
    }
}
