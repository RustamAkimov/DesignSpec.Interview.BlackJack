using System.Collections.Generic;

namespace BlackJack
{
    public abstract class CardHand
    {
        protected List<Card> _cards;
        
        protected CardHand(IList<Card> initialCards)
        {
            _cards = new List<Card>(initialCards);
        }

        public void Add(Card card)
        {
            _cards.Add(card);
        }

        public abstract string GetValue();
    }
}