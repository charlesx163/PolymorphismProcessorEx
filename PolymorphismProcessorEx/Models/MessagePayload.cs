namespace PolymorphismProcessorEx.Models
{
    public class MessagePayload
    {
        public string? Message { get; set; }
        public MessageType MessageType { get; set; }
    }


    public enum MessageType {
        Info,
        Warning,
        Error
    }

}
