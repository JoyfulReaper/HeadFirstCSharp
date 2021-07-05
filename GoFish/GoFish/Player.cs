using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoFish
{
    public class Player
    {
        public static Random Random = new Random();

        private List<Card> hand = new List<Card>();
        private List<Values> books = new List<Values>();

        /// <summary>
        /// The cards in the player's hand
        /// </summary>
        public IEnumerable<Card> Hand => hand;

        /// <summary>
        /// The books that the player has pulled out
        /// </summary>
        public IEnumerable<Values> Books => books;

        public readonly string Name;

        public static string S(int s) => s == 1 ? "" : "s";

        /// <summary>
        /// Returns the current status of the player: the number of cards and books
        /// </summary>
        public string Status => $"{Name} has {hand.Count} card{S(hand.Count)} and {books.Count} book{S(books.Count)}";

        public Player(string name) => Name = name;

        public Player(string name, IEnumerable<Card> cards)
        {
            Name = name;
            hand.AddRange(cards);
        }

        /// <summary>
        /// Gets up to five cards from the stock
        /// </summary>
        /// <param name="stock"></param>
        public void GetNextHand(Deck stock)
        {
            while(stock.Count > 0 && hand.Count < 5)
            {
                hand.Add(stock.Deal(0));
            }
        }

        /// <summary>
        /// If I have any cards that match the value, return them. If I run out of cards, get
        /// the next hand from the deck.
        /// </summary>
        /// <param name="value">Value I am asked for</param>
        /// <param name="deck">Deck to draw my next hand from</param>
        /// <returns>The cards that were pulled out of the other player's hand</returns>
        public IEnumerable<Card> DoYouHaveAny(Values value, Deck deck)
        {
            var matchingCards = 
                hand.Where(card => card.Value == value)
                .OrderBy(card => card.Suit);

            hand = hand.Where(card => card.Value != value).ToList();

            if(hand.Count < 1)
            {
                GetNextHand(deck);
            }

            return matchingCards;
        }

        /// <summary>
        /// When the player recives cards from another player, adds them to the hand
        /// and pulls out any matching books
        /// </summary>
        /// <param name="cards">Cards from the other player to add</param>
        public void AddCardsAndPullOutBooks(IEnumerable<Card> cards)
        {
            hand.AddRange(cards);

            var foundBooks = hand
                .GroupBy(card => card.Value)
                .Where(group => group.Count() == 4)
                .Select(group => group.Key);

            books.AddRange(foundBooks);
            books.Sort();

            hand = hand.Where(card => !books.Contains(card.Value))
                .ToList();
        }

        /// <summary>
        /// Draws a card from the stock and adds it to the player's hand
        /// </summary>
        /// <param name="stock"></param>
        public void DrawCard(Deck stock)
        {
            if(stock.Count > 0)
            {
                hand.Add(stock.Deal(0));
            }
        }

        public Values RandomValueFromHand() => hand[Random.Next(0, hand.Count)].Value;

        public override string ToString() => Name;
    }
}
