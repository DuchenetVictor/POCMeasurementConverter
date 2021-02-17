using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Windows.Input;
using MahApps.Metro.Controls;

namespace POCMeasurementConverter.View
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            var measurementValue = e.Source as TextBox;
            Regex regex;
            if (measurementValue.Text.Contains(","))
                regex = new Regex("[^0-9]+");
            else
                regex = new Regex("[^0-9,]+");

            e.Handled = regex.IsMatch(e.Text);
        }

    }
}
