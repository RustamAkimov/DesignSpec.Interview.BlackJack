using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace BlackJack
{
    
    public class BlackJackHand:CardHand
    {
        public BlackJackHand(IList<Card> initialCards) : base(initialCards)
        {
        }

        public override string GetValue()
        {
            var aceNumber = 0;
            var totalValue = 0;
            
            foreach (var card in _cards)
            {
                if (card.Rank == CardRank.Ace)
                {
                    ++aceNumber;
                }
                else
                {
                    totalValue += GetValue(card);
                }
                
            }

        
            var possibleExtraValues = GeneratePossibleValue(aceNumber);

            var returnValue = totalValue;
            foreach (var extraValue in possibleExtraValues)
            {
                var candidateValue = extraValue + totalValue;
                if (candidateValue <= 21 && candidateValue>returnValue)
                    returnValue = extraValue + totalValue;
            }

            return ShowValue(returnValue);
        }

        private string ShowValue(int totalValue)
        {
            if(totalValue==21)
                return "blackjack";
            if (totalValue > 21)
                return "over 21";
            
            return totalValue.ToString();
        }

        

        private int[] GeneratePossibleValue(int aceNumber)
        {
            switch (aceNumber)
            {
                case 0:
                    return new int[0];
                case 1:
                    return new[] {1, 11};
                case 2:
                    return new[] {2, 12};
                case 3:
                    return new[] {3, 13};
                case 4:
                    return new[] {4, 14};
                default:
                    throw new ArgumentException("Ace number cannot be different from 0 to 4");
                    
            }
        }

        public int GetValue(Card card)
        {
            if (new[] {CardRank.Jack, CardRank.Queen, CardRank.King}.Contains(card.Rank))
                return 10;

            return Int32.Parse(card.Rank.GetAttribute<DisplayAttribute>().Name);

        }
    }
}