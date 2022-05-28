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

namespace MatchGame;
/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private static Random _random = new Random();
    private TextBlock _lastTextBlockClicked;
    private bool _findingMatch = false;
    private DispatcherTimer _timer = new DispatcherTimer();
    private int _tenthsOfSecondsElapsed;
    private int _matchesFound;

    public MainWindow()
    {
        InitializeComponent();

        _timer.Interval = TimeSpan.FromSeconds(.1);
        _timer.Tick += Timer_Tick;
        SetupGame();
    }

    private void Timer_Tick(object? sender, EventArgs e)
    {
        _tenthsOfSecondsElapsed++;
        timeTextBlock.Text = (_tenthsOfSecondsElapsed / 10F).ToString("0.0s");
        if (_matchesFound == 8)
        {
            _timer.Stop();
            timeTextBlock.Text += " - Play again?";
        }
    }

    private void SetupGame()
    {
        List<string> _animalEmoji = new List<string>
        {
            "🦑", "🦑",
            "👻", "👻",
            "🐖", "🐖",
            "👽", "👽",
            "🦥", "🦥",
            "🦄", "🦄",
            "🐳", "🐳",
            "🦉", "🦉",
        };

        foreach (TextBlock textBlock in mainGrid.Children.OfType<TextBlock>())
        {
            if (textBlock.Name == "timeTextBlock")
            {
                continue;
            }

            textBlock.Visibility = Visibility.Visible;
            int index = _random.Next(_animalEmoji.Count);
            string nextEmoji = _animalEmoji[index];
            textBlock.Text = nextEmoji;
            _animalEmoji.RemoveAt(index);
        }

        _timer.Start();
        _tenthsOfSecondsElapsed = 0;
        _matchesFound = 0;
    }

    private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
    {
        TextBlock textBlock = sender as TextBlock;
        if (textBlock == null)
        {
            throw new Exception("Sender must be a TextBlock");
        }

        if(!_findingMatch)
        {
            textBlock.Visibility = Visibility.Hidden;
            _lastTextBlockClicked = textBlock;
            _findingMatch = true;
        }
        else if (textBlock.Text == _lastTextBlockClicked.Text)
        {
            textBlock.Visibility = Visibility.Hidden;
            _findingMatch = false;
            _matchesFound++;
        }
        else
        {
            _lastTextBlockClicked.Visibility = Visibility.Visible;
            _findingMatch = false;
        }
    }

    private void TimeTextBlock_MouseDown(object sender, MouseButtonEventArgs e)
    {
        if(_matchesFound == 8)
        {
            SetupGame();
        }
    }
}
