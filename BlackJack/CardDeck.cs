using System;
using System.Collections.Generic;

namespace BlackJack
{
    public class CardDeck
    {
        private CardDeck()
        {
            
        }

        private List<Card> _cardList;

        public static CardDeck Generate52Deck()
        {
            var deck = new CardDeck();

            deck.Init52Desk();
            deck.Shuffle();
            
            return deck;
        }

        public void Init52Desk()
        {
            _cardList = new List<Card>();

            var suits = (CardSuit[]) Enum.GetValues(typeof(CardSuit));
            var ranks = (CardRank[]) Enum.GetValues(typeof(CardRank));
            
            foreach (var suit in suits)
            {
                foreach (var rank in ranks)
                {
                    _cardList.Add(new Card(rank, suit));
                }
            }
        }

        public void Shuffle()
        {
            _cardList.Shuffle();
        }

        public bool IsEmpty => _cardList.Count > 0;

        public Card GetCard()
        {
            return _cardList.RemoveAndReturnFirst();
        }
    }
}