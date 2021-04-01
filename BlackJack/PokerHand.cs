using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace BlackJack
{
    public class PokerHand : CardHand
    {
        public PokerHand(IList<Card> initialCards) : base(initialCards)
        {
        }

        protected IList<Card> OrderedCards =>
            _cards.OrderBy(c => c.Rank.GetAttribute<DisplayAttribute>().Order).ToList();

        public bool IsStraight
        {
            get
            {

                for (int i = 0; i < OrderedCards.Count - 1; i++)
                {
                    var rank = OrderedCards[i].Rank.GetAttribute<DisplayAttribute>().Order;
                    var nextRank = OrderedCards[i+1].Rank.GetAttribute<DisplayAttribute>().Order;

                    if (rank + 1 != nextRank)
                        return false;
                }

                return true;
            }
        }

        public bool IsFourOfKind => SameKind(4);

        public bool IsThreeOfKind => SameKind(3);

        public bool IsPair => SameKind(2);

        private Dictionary<CardRank, int> GetGroupedByRank()
        {
            var rank2Num = new Dictionary<CardRank, int>();
            foreach (var card in _cards)
            {
                if (!rank2Num.ContainsKey(card.Rank))
                    rank2Num[card.Rank] = 1;
                else
                {
                    rank2Num[card.Rank] += 1;
                }
            }

            return rank2Num.OrderByDescending(r2n => r2n.Value).ToDictionary(r2n => r2n.Key, 
                r2n=>r2n.Value);
        }
        
        private bool SameKind(int number)
        {
            if (_cards.Count < number)
                return false;

            return GetGroupedByRank().Any(k2v => k2v.Value == number);
        }

        public bool IsFlush => _cards.All(c => c.Suit == _cards.First().Suit);

        public bool IsStraightFlush => IsFlush && IsStraight;

        public bool IsRoyalFlush => _cards.Count == 5 && IsStraightFlush && OrderedCards.First().Rank == CardRank.Ten;

        public bool IsFullHouse
        {
            get
            {
                if (_cards.Count != 5)
                    return false;
                
                var rank2Num = GetGroupedByRank();

                return rank2Num.Count == 2 && rank2Num.First().Value == 3 && rank2Num.Last().Value == 2;
            }
        }

        public bool IsTwoPair
        {
            get
            {
                if (_cards.Count < 4)
                    return false;
                
                var rank2Num = GetGroupedByRank();

                return rank2Num.Count == 2 && rank2Num.First().Value == 2 && rank2Num.ElementAt(1).Value == 2;
            }
        }
        
        public override string GetValue()
        {
            //*(2+)Pair
            //*(4+)Two Pair
            //*(3+)Three of Kind
            //*(5)Straight
            //*(5)Flush 
            //*(5)Full House = Three of Kind + pair
            //*(4+)Four of Kind 
            //*(5)Straight Flush = Straight & Flush
            //*(5)Royal Flush = StraightFlush & Start with Ace

            if (IsRoyalFlush)
                return "royal flush";

            if (IsStraightFlush)
                return "straight flush";

            if (IsFourOfKind)
                return "four kind";

            if (IsFullHouse)
                return "full house";

            if (IsFlush)
                return "four of kind";

            if (IsStraight)
                return "straight";

            if (IsThreeOfKind)
                return "three of kind";

            if (IsTwoPair)
                return "two pair";

            if (IsPair)
                return "is pair";


            return _cards.OrderByDescending(c => c.Rank.GetAttribute<DisplayAttribute>().Order).First().ToString();
        }
    }
}