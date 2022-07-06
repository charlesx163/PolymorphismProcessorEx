namespace PolymorphismProcessorEx.Core
{
    /// <summary>
    /// A common abstract Background service
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class JobHostedService<T> : BackgroundService,IJobHostedService where T:IHostedService
    {
        private readonly IJobExecutor _executor;
        private readonly ILogger<T> _logger;
        public abstract string ServiceName { get; }
        protected JobHostedService(IJobExecutor executor,
            ILogger<T> logger)
        {
            _executor = executor;
            _logger = logger;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            try
            {
                _logger.LogInformation("{0} is starting.", ServiceName);
                while (!stoppingToken.IsCancellationRequested)
                {
                    var num = await _executor.Execute(stoppingToken);
                    TimeSpan delayTime = ((num > 0) ? TimeSpan.FromSeconds(5) : TimeSpan.FromSeconds(15));
                    await Task.Delay(delayTime, stoppingToken);
                }
            }
            catch(Exception e)
            {
                _logger.LogError(e.Message,e);
            }
        }
    }
}
