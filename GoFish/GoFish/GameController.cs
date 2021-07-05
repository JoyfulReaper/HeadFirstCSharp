using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoFish
{
    public class GameController
    {
        public static Random Random = new();

        private GameState gameState;
        public bool GameOver { get => gameState.GameOver; }
        public Player HumanPlayer { get => gameState.HumanPlayer; }
        public IEnumerable<Player> Opponents { get => gameState.Opponents; }
        public string Status { get; private set; }

        public GameController(string humanPlayerName, IEnumerable<string> computerPlayerName)
        {
            gameState = new GameState(humanPlayerName, computerPlayerName, new Deck());
            Status = $"Starting a new game with players {string.Join(", ", gameState.Players)}";
        }

        /// <summary>
        /// PLays the next round, ending the game if everyone ran out of cards
        /// </summary>
        /// <param name="playerToAsk">Player human is asking cards for</param>
        /// <param name="valueToAskFor">Card human is asking for</param>
        public void NextRound(Player playerToAsk, Values valueToAskFor)
        {
            Status = gameState.PlayRound(HumanPlayer, playerToAsk, valueToAskFor, gameState.Stock) + Environment.NewLine;

            ComputerPlayersPlayNextRound();

            Status += HumanPlayer.Status + Environment.NewLine;
            Status += $"The stock has {gameState.Stock.Count()} cards" + Environment.NewLine;

            Status += gameState.CheckForWinner();
        }

        private void ComputerPlayersPlayNextRound()
        {
            IEnumerable<Player> computersWithCards;

            do
            {
                computersWithCards = gameState.Opponents
                   .Where(player => player.Hand.Count() > 0);

                foreach (var o in computersWithCards)
                {
                    var playerToAsk = gameState.RandomPlayer(o);
                    var valueToAskFor = o.RandomValueFromHand();

                    Status += gameState.PlayRound(o, playerToAsk, valueToAskFor, gameState.Stock) + Environment.NewLine;

                }
            } while (gameState.HumanPlayer.Hand.Count() == 0
                        && computersWithCards.Count() > 0);
        }

        public void NewGame()
        {
            Status = "Starting a new game";
            gameState = new GameState(gameState.HumanPlayer.Name,
                gameState.Opponents.Select(player => player.Name),
                new Deck().Shuffle());
        }
    }
}
