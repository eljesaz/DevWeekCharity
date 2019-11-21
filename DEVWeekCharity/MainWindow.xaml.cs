using DEVWeekCharity.Model;
using System;
using System.IO;
using System.Windows;

namespace DEVWeekCharity
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public StartingScreen _startingScreen = new StartingScreen();
        public MainWindow()
        {
            InitializeComponent();
            if (_startingScreen.RemainingSum <= 0) SetRemainingSumToZeroAndDisableDonateButtons();
            DataContext = _startingScreen;
        }
        private void Donated50(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Thank you for your generosity!");
            RemoveFromRemainingSum(50);
        }
        private void Donated100(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Thank you for your generosity!");
            RemoveFromRemainingSum(100);
        }
       
        private void Donated150(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Thank you for your generosity!");
            RemoveFromRemainingSum(150);
        }

        private void Donated200(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Thank you for your generosity!");
            RemoveFromRemainingSum(200);
        }
        private void Donated500(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Thank you for your generosity!");
            RemoveFromRemainingSum(500);
        }
        private void RemoveFromRemainingSum(int justDonated)
        {
            var allLines = File.ReadAllLines(Path.GetFullPath(Constants.RecourseRelativePath));
            allLines[0] = (Convert.ToInt32(_startingScreen.RemainingSum) - justDonated).ToString();
            if (Convert.ToInt32(allLines[0]) <= 0)
            {
                SetRemainingSumToZeroAndDisableDonateButtons();
            }
            else
            {
                _startingScreen.RemainingSum = Convert.ToInt32(allLines[0]);
            }

            File.WriteAllLines(Constants.RecourseRelativePath, allLines);
        }

        private void SetRemainingSumToZeroAndDisableDonateButtons()
        {
            _startingScreen.RemainingSum = 0;
            _startingScreen.InfoMessage = Constants.CannotDonate;
            Button50.IsEnabled = false;
            Button100.IsEnabled = false;
            Button150.IsEnabled = false;
            Button200.IsEnabled = false;
            Button500.IsEnabled = false;
        }
    }
}
