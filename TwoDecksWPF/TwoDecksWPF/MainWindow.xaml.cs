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

namespace TwoDecksWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            (Resources["RightDeck"] as Deck).Clear();
        }

        private void MoveCard(bool leftToRight)
        {
            if((Resources["RightDeck"] is Deck rightDeck) && (Resources["LeftDeck"] is Deck leftDeck))
            {
                if(leftToRight)
                {
                    if(leftDeckListBox.SelectedItem is Card card)
                    {
                        leftDeck.Remove(card);
                        rightDeck.Add(card);
                    }
                }
                else
                {
                    if(rightDeckListBox.SelectedItem is Card card)
                    {
                        rightDeck.Remove(card);
                        leftDeck.Add(card);
                    }
                }
            }
        }

        private void shuffleLeftDeck_Click(object sender, RoutedEventArgs e)
        {
            var leftDeck = Resources["LeftDeck"] as Deck;
            leftDeck.Shuffle();
        }

        private void clearRightDeck_Click(object sender, RoutedEventArgs e)
        {
            var rightDeck = Resources["RightDeck"] as Deck;
            rightDeck.Clear();
        }

        private void resetLeftDeck_Click(object sender, RoutedEventArgs e)
        {
            var leftDeck = Resources["LeftDeck"] as Deck;
            leftDeck.Reset();
        }

        private void sortRightDeck_Click(object sender, RoutedEventArgs e)
        {
            var rightDeck = Resources["RightDeck"] as Deck;
            rightDeck.Sort();
        }

        private void leftDeckListBox_KeyDown(object sender, KeyEventArgs e)
        {
            MoveCard(true);
        }

        private void leftDeckListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            MoveCard(true);
        }

        private void rightDeckListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            MoveCard(false);
        }

        private void rightDeckListBox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                MoveCard(false);
            }
        }
    }
}
