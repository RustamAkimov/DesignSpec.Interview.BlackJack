using NUnit.Framework;

namespace BlackJack.Tests
{
    public class PokerHandTests
    {
        [Test]
        public void TestRoyalFlush()
        {
            var hand = new PokerHand(new[]
            {
                new Card(CardRank.Ace, CardSuit.Clubs),
                new Card(CardRank.King, CardSuit.Clubs),
                new Card(CardRank.Queen, CardSuit.Clubs),
                new Card(CardRank.Jack, CardSuit.Clubs),
                new Card(CardRank.Ten, CardSuit.Clubs)
            });

            Assert.IsTrue(hand.IsRoyalFlush);
            
            var hand2 = new PokerHand(new[]
            {
                new Card(CardRank.Ace, CardSuit.Clubs),
                new Card(CardRank.King, CardSuit.Clubs),
                new Card(CardRank.Queen, CardSuit.Diamonds),
                new Card(CardRank.Jack, CardSuit.Clubs),
                new Card(CardRank.Ten, CardSuit.Clubs)
            });

            Assert.IsFalse(hand2.IsRoyalFlush);
            
            var hand3 = new PokerHand(new[]
            {
                new Card(CardRank.King, CardSuit.Clubs),
                new Card(CardRank.Queen, CardSuit.Clubs),
                new Card(CardRank.Jack, CardSuit.Clubs),
                new Card(CardRank.Ten, CardSuit.Clubs),
                new Card(CardRank.Nine, CardSuit.Clubs),

            });

            Assert.IsFalse(hand3.IsRoyalFlush);
        }
        
        [Test]
        public void TestStraightFlush()
        {
            var hand = new PokerHand(new[]
            {
                new Card(CardRank.Nine, CardSuit.Clubs),
                new Card(CardRank.Eight, CardSuit.Clubs),
                new Card(CardRank.Seven, CardSuit.Clubs),
                new Card(CardRank.Six, CardSuit.Clubs),
                new Card(CardRank.Five, CardSuit.Clubs)
            });

            Assert.IsTrue(hand.IsStraightFlush);
            
            var hand2 = new PokerHand(new[]
            {
                new Card(CardRank.Nine, CardSuit.Clubs),
                new Card(CardRank.Eight, CardSuit.Clubs),
                new Card(CardRank.Seven, CardSuit.Diamonds),
                new Card(CardRank.Six, CardSuit.Clubs),
                new Card(CardRank.Five, CardSuit.Clubs)
            });

            Assert.IsFalse(hand2.IsStraightFlush);
            
            var hand3 = new PokerHand(new[]
            {
                new Card(CardRank.Nine, CardSuit.Clubs),
                new Card(CardRank.Eight, CardSuit.Clubs),
                new Card(CardRank.Seven, CardSuit.Clubs),
                new Card(CardRank.Six, CardSuit.Clubs),
                new Card(CardRank.Four, CardSuit.Clubs),

            });

            Assert.IsFalse(hand3.IsStraightFlush);
        }
        
        [Test]
        public void TestFourOfKind()
        {
            var hand = new PokerHand(new[]
            {
                new Card(CardRank.Ace, CardSuit.Clubs),
                new Card(CardRank.Ace, CardSuit.Diamonds),
                new Card(CardRank.Seven, CardSuit.Clubs),
                new Card(CardRank.Ace, CardSuit.Hearts),
                new Card(CardRank.Ace, CardSuit.Spades)
            });

            Assert.IsTrue(hand.IsFourOfKind);
            
            var hand2 = new PokerHand(new[]
            {
                new Card(CardRank.Ace, CardSuit.Clubs),
                new Card(CardRank.Ace, CardSuit.Spades),
                new Card(CardRank.Ace, CardSuit.Diamonds),
                new Card(CardRank.Six, CardSuit.Clubs),
                new Card(CardRank.Five, CardSuit.Clubs)
            });

            Assert.IsFalse(hand2.IsFourOfKind);
            
            var hand3 = new PokerHand(new[]
            {
                new Card(CardRank.Ace, CardSuit.Clubs),
                new Card(CardRank.Ace, CardSuit.Diamonds),
                new Card(CardRank.Ace, CardSuit.Spades),
         
            });

            Assert.IsFalse(hand3.IsFourOfKind);
        }
        
    }
}