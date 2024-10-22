namespace WpfGenericHost;

internal class Program
{
	[STAThread()]
	public static void Main()
	{
		var app = new App();
		app.InitializeComponent();
		app.Run();
	}
}
