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

namespace TCTWindow
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public int testfcount = 0;

        public MainWindow()
        {
            InitializeComponent();
            this.TextBblockData.Text = $@"{testfcount}";
        }

        private void DoButtonYes(object sender, RoutedEventArgs e)
        {
            //this.ButtonText.Content = @"666";
            testfcount += 1;
            this.TextBblockData.Text = $@"{testfcount}";
        }
    }

}