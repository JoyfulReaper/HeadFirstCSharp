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
using System.Windows.Threading;

namespace MatchGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DispatcherTimer _timer = new DispatcherTimer();
        private int _tenthsOfSecondsElapsed;
        private int _matchesFound;

        private TextBlock _lastTextBoxClicked;
        private bool _findingMatch = false;

        public MainWindow()
        {
            InitializeComponent();

            _timer.Interval = TimeSpan.FromSeconds(.1);
            _timer.Tick += _timer_Tick;
            SetupGame();
        }

        private void _timer_Tick(object sender, EventArgs e)
        {
            _tenthsOfSecondsElapsed++;
            timerTextBlock.Text = (_tenthsOfSecondsElapsed / 10F).ToString("0.0s");
            if(_matchesFound == 8)
            {
                _timer.Stop();
                timerTextBlock.Text = timerTextBlock.Text + " - Play again?";
            }
        }

        private void SetupGame()
        {
            List<string> animalEmoji = new List<string>()
            {
                "😺", "😺",
                "🦊", "🦊",
                "🐞", "🐞",
                "🕷", "🕷",
                "🦆", "🦆",
                "🦑", "🦑",
                "🐖", "🐖",
                "👻", "👻"
            };

            Random random = new Random();

            foreach(TextBlock textBlock in mainGrid.Children.OfType<TextBlock>())
            {
                if (textBlock.Name != "timerTextBlock")
                {
                    textBlock.Visibility = Visibility.Visible;
                    int index = random.Next(animalEmoji.Count);
                    string nextEmoji = animalEmoji[index];
                    textBlock.Text = nextEmoji;
                    animalEmoji.RemoveAt(index);
                }
            }

            _timer.Start();
            _tenthsOfSecondsElapsed = 0;
            _matchesFound = 0;
        }

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            TextBlock textBlock = sender as TextBlock;
            if(!_findingMatch)
            {
                textBlock.Visibility = Visibility.Hidden;
                _lastTextBoxClicked = textBlock;
                _findingMatch = true;
            }
            else if(textBlock.Text == _lastTextBoxClicked.Text)
            {
                _matchesFound++;
                textBlock.Visibility = Visibility.Hidden;
                _findingMatch = false;
            }
            else
            {
                _lastTextBoxClicked.Visibility = Visibility.Visible;
                _findingMatch = false;
            }
        }

        private void timeTextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(_matchesFound == 8)
            {
                SetupGame();
            }
        }
    }
}
