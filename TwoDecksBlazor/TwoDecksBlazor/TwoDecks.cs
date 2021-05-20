using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TwoDecksBlazor
{
    class TwoDecks
    {
        private  Deck _leftDeck = new Deck();
        private  Deck _rightDeck = new Deck();

        public int LeftDeckCount { get => _leftDeck.Count; }
        public int LeftCardSelected { get; set; }

        public int RightDeckCount { get => _rightDeck.Count; }
        public int RightCardSelected { get; set; }

        public string LeftDeckCardName(int i)
        {
            if (_leftDeck.Count == 0 || i < 0 || i >= _leftDeck.Count)
            {
                return string.Empty;
            }

            return _leftDeck[i].ToString();
        }

        public string RightDeckCardName(int i)
        {
            if(_rightDeck.Count == 0 || i < 0 || i >= _rightDeck.Count)
            {
                return string.Empty;
            }

            return _rightDeck[i].ToString();
        }

        public void Shuffle()
        {
            _leftDeck.Shuffle();
        }

        public void Reset()
        {
            _leftDeck = new Deck();
        }

        public void Sort()
        {
            _rightDeck.Sort(new CardComparerByValue());
        }

        public void Clear()
        {
            _rightDeck.Clear();
        }

        public void MoveCard(Direction direction)
        {
            if(direction == Direction.LeftToRight)
            {
                if (_leftDeck.Count == 0 || LeftCardSelected >= _leftDeck.Count)
                    return;

                _rightDeck.Add(_leftDeck[LeftCardSelected]);
                _leftDeck.RemoveAt(LeftCardSelected);
            }
            else
            {
                if (_rightDeck.Count == 0 || RightCardSelected >= _rightDeck.Count)
                    return;

                _leftDeck.Add(_rightDeck[RightCardSelected]);
                _rightDeck.RemoveAt(RightCardSelected);
            }
        }
    }
}
