using PolymorphismProcessorEx.Models;

namespace PolymorphismProcessorEx.Core.PayloadProcessors
{
    public delegate IPayloadProcessor? PayloadProcessorFactory(MessageType type);
}
    
