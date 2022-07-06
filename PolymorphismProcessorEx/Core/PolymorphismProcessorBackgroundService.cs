namespace PolymorphismProcessorEx.Core
{
    public class PolymorphismProcessorBackgroundService : JobHostedService<PolymorphismProcessorBackgroundService>
    {
        public PolymorphismProcessorBackgroundService(IJobExecutor executor, ILogger<PolymorphismProcessorBackgroundService> logger) : base(executor, logger)
        {
        }

        public override string ServiceName => nameof(PolymorphismProcessorBackgroundService);
    }
}
