using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace BlackJack
{
    public class Card
    {
        public CardRank Rank { get; private set; }
        
        public CardSuit Suit { get; private set; }

        public Card(CardRank rank, CardSuit suit)
        {
            Rank = rank;
            Suit = suit;
        }

        public override string ToString()
        {
            return Rank.GetAttribute<DisplayAttribute>().Name + Suit.GetAttribute<DisplayAttribute>().Name;

        }
        
    }
    
   
}