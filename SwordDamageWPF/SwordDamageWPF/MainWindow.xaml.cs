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

namespace SwordDamageWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Random _random = new Random();
        SwordDamage _swordDamage;

        public MainWindow()
        {
            InitializeComponent();

            _swordDamage = new SwordDamage(_random.Next(1, 7) + _random.Next(1, 7) + _random.Next(1, 7));
            DisplayDamage();
        }

        public void RollDice()
        {
            _swordDamage.Roll = _random.Next(1, 7) + _random.Next(1, 7) + _random.Next(1, 7);
            DisplayDamage();
        }

        void DisplayDamage()
        {
            damage.Text = $"Rolled {_swordDamage.Roll} for {_swordDamage.Damage}  HP";
        }

        private void flaming_Checked(object sender, RoutedEventArgs e)
        {
            _swordDamage.Flaming = true;
            DisplayDamage();
        }

        private void flaming_Unchecked(object sender, RoutedEventArgs e)
        {
            _swordDamage.Flaming = false;
            DisplayDamage();
        }

        private void magic_Checked(object sender, RoutedEventArgs e)
        {
            _swordDamage.Magic = true;
            DisplayDamage();
        }

        private void magic_Unchecked(object sender, RoutedEventArgs e)
        {
            _swordDamage.Magic = false;
            DisplayDamage();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RollDice();
        }
    }
}
