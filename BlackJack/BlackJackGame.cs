using System;

namespace BlackJack
{
    public class BlackJackGame
    {
        private CardDeck _deck;

        private BlackJackHand _hand;
        
        public (Card firstCard, Card secondCard) StartGame()
        {
            _deck = CardDeck.Generate52Deck();

            var firstCard = _deck.GetCard();
            var secondCard = _deck.GetCard();

            _hand = new BlackJackHand(new[]{firstCard, secondCard});

            return (firstCard, secondCard);
        }

        public Card More()
        {
            var card= _deck.GetCard();
            _hand.Add(card);

            return card;
        }

        public string Finish()
        {
            return _hand.GetValue();
        }
    }
}