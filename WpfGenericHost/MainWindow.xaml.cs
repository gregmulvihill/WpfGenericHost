using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using WpfGenericHost.Services;

namespace WpfGenericHost
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private readonly IMyService _myService;

		public MainWindow()
		{
		}

		public MainWindow(IMyService myService)
		{
			_myService = myService;
			InitializeComponent();
		}
	}
}