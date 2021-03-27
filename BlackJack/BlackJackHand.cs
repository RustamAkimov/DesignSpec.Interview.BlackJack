using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace BlackJack
{

    public class BlackJackHand : CardHand
    {
        private const string BlackJackStr = "blackjack";
        
        public BlackJackHand(IList<Card> initialCards) : base(initialCards)
        {
        }

        public int GetValueInt()
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


            var possibleExtraValues = GeneratePossibleAceValues(aceNumber);

            var returnValue = totalValue;
            foreach (var extraValue in possibleExtraValues)
            {
                var candidateValue = extraValue + totalValue;
                if (candidateValue <= 21 && candidateValue > returnValue)
                    returnValue = extraValue + totalValue;
            }

            return returnValue;

        }

        public override string GetValue()
        {
            return ShowValue(GetValueInt());
        }

        private string ShowValue(int totalValue)
        {
            if (totalValue == 21)
                return BlackJackStr;
            if (totalValue > 21)
                return "over 21";

            return totalValue.ToString();
        }

        

        private int[] GeneratePossibleAceValues(int aceNumber)
        {
            if (aceNumber==0)
                return new int[0];

            return new[] {aceNumber, aceNumber + 10};

            // switch (aceNumber)
            // {
            //     case 0:
            //        
            //     case 1:
            //         return new[] {1, 11};
            //     case 2:
            //         return new[] {2, 12};
            //     case 3:
            //         return new[] {3, 13};
            //     case 4:
            //         return new[] {4, 14};
            //     default:
            //         throw new ArgumentException("Ace number cannot be different from 0 to 4");
            //
            // }
        }

        public int GetValue(Card card)
        {
            if (new[] {CardRank.Jack, CardRank.Queen, CardRank.King}.Contains(card.Rank))
                return 10;

            return Int32.Parse(card.Rank.GetAttribute<DisplayAttribute>().Name);

        }
    }
}