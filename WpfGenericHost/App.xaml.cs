using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using System.Windows;

using WpfGenericHost;
using WpfGenericHost.Services;

namespace WpfGenericHost;

public partial class App : Application
{
	private IHost _host;

	protected override async void OnStartup(StartupEventArgs e)
	{
		AppDomain.CurrentDomain.UnhandledException += (s, args) => MessageBox.Show(((Exception)args.ExceptionObject).Message);

		DispatcherUnhandledException += (s, args) =>
		{
			MessageBox.Show(args.Exception.Message);
			args.Handled = true;
		};

		base.OnStartup(e);

		_host = Host.CreateDefaultBuilder(e.Args)
			 .ConfigureServices((context, services) =>
			 {
				 // Register services here
				 services.AddSingleton<IMyService, MyService>();
				 services.AddSingleton<MainWindow>();  // Register MainWindow for DI
			 })
			 .Build();

		await _host.StartAsync();

		// Resolve MainWindow using DI
		var mainWindow = _host.Services.GetRequiredService<MainWindow>();
		mainWindow.Show();
	}

	protected override async void OnExit(ExitEventArgs e)
	{
		await _host.StopAsync();
		_host.Dispose();
		base.OnExit(e);
	}
}
