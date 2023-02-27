namespace WorkerService1
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        readonly Logger _log;
        readonly IConfiguration _configuration;

        public Worker(Logger log,ILogger<Worker> logger,IConfiguration configuration)
        {
            _logger = logger;
            _log = log;
            _configuration= configuration;  
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _log.WriteToLogFile(ActionTypeEnum.Information, "loggging");
                //_logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await Task.Delay(Convert.ToInt32(_configuration.GetSection("TimeInterval").Value),
                    stoppingToken);
            }
        }
    }
}