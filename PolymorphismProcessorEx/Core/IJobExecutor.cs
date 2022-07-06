namespace PolymorphismProcessorEx.Core
{
    public interface IJobExecutor
    {
        Task<int> Execute(CancellationToken token);
    }
}
