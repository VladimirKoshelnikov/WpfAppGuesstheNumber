using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfAppGuesstheNumber
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int _num = 0;
        private bool isGameStarted = false;
        private bool isNumberBiggger = false;
        private bool isNumberSmalller = false;

        public MainWindow()
        {

            InitializeComponent();
            Number.Text = "Your number";
        }

        private void Guess_Click(object sender, RoutedEventArgs e)
        {
            if (!isGameStarted)
            {
                Random random = new Random();
                _num = random.Next(100);

                isGameStarted = true;
                Guess.Content = "Guess";

                Number.Text = "0";
            }
            else
            {
                CheckNumber();
            }
        }

        private void CheckNumber()
        {
            int yourNumber = 0;
            if (int.TryParse(Number.Text, out yourNumber))
            {
                isNumberBiggger = yourNumber > _num;
                isNumberSmalller = yourNumber < _num;

                if (isNumberBiggger == false & isNumberSmalller == false)
                {
                    GameName.Content = "You win";
                    Guess.IsEnabled = false;
                    Number.IsEnabled = false;
                }
                if (isNumberBiggger)
                {
                    GameName.Content = "You number is bigger";
                }
                if (isNumberSmalller)
                {
                    GameName.Content = "You number is smaller";
                }
            }
        }

        private void Number_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                CheckNumber();
            }
        }
    }
}
