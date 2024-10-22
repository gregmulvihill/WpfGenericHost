using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace WpfGenericHost.Services
{
	public class MyService : IMyService
	{
		private readonly ILogger<MyService> _logger;
		private readonly MyAppSettings _settings;

		public MyService(ILogger<MyService> logger, IOptions<MyAppSettings> settings)
		{
			_logger = logger;
			_settings = settings.Value;
		}

		public void DoWork()
		{
			Console.WriteLine(_settings.Setting1);
		}
	}

}
