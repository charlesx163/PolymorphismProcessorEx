# PolymorphismProcessorEx Background service
This a project used .Net6
In this Project, it use the abstract, Polymorphism, delegate register

#Tech Note

``` c#
builder.Services.AddSingleton<NormalPayloadProcessor>()
    .AddSingleton<ErrorPayloadProcessor>()
    .AddSingleton<PayloadProcessorFactory>(sp => messageType => messageType switch
    {
        MessageType.Info => sp.GetService<NormalPayloadProcessor>(),
        MessageType.Error => sp.GetService<ErrorPayloadProcessor>(),
        _ => null
    });
builder.Services.AddTransient<PayloadProcessorConfiguration>();
//register runner and config how many processors
builder.Services.AddSingleton(sp =>
{
    var payloadProcessorConfiguration = sp.GetService<PayloadProcessorConfiguration>()!;
    payloadProcessorConfiguration.AddProcessor(MessageType.Info)
    .AddProcessor(MessageType.Error);
    return payloadProcessorConfiguration.CreateRunner();

});
```
