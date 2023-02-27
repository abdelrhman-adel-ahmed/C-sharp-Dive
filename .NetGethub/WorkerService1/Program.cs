using WorkerService1;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<Worker>();
        services.AddSingleton<Logger>();
    })
    .UseWindowsService()
    .Build();

await host.RunAsync();
