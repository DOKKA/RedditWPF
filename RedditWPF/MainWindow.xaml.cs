using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
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

namespace RedditWPF
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			
			MainViewModel vm = new MainViewModel();
			this.DataContext = vm;
			RedditService rs = new RedditService();
		}

		private void RadExpander_PreviewCollapsed(object sender, Telerik.Windows.RadRoutedEventArgs e)
		{
			firstColumn.Width = GridLength.Auto;
		}

		private void RadExpander_PreviewCollapsed_1(object sender, Telerik.Windows.RadRoutedEventArgs e)
		{
			lastColumn.Width = GridLength.Auto;
		}

		private void RadExpander_PreviewCollapsed_2(object sender, Telerik.Windows.RadRoutedEventArgs e)
		{
			midColumn.Width = GridLength.Auto;
		}
	}
}
