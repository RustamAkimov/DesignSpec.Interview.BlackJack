using NUnit.Framework;

namespace BlackJack.Tests
{
    public class BlackJackHandTests
    {
        [Test]
        public void AceAnd10ShouldReturnBlackjack()
        {
            var hand = new BlackJackHand(new[]
                {new Card(CardRank.Ace, CardSuit.Clubs), new Card(CardRank.Ten, CardSuit.Diamonds)});
            
            Assert.AreEqual("blackjack", hand.GetValue());
        }
        
        [Test]
        public void TwoAceShouldReturn12()
        {
            var hand = new BlackJackHand(new[]
                {new Card(CardRank.Ace, CardSuit.Clubs), new Card(CardRank.Ace, CardSuit.Diamonds)});
            
            Assert.AreEqual(12, hand.GetValueInt());
        }
        
        [Test]
        public void FourAceAnd7ShouldReturn21()
        {
            var hand = new BlackJackHand(new[]
                {new Card(CardRank.Ace, CardSuit.Clubs), 
                    new Card(CardRank.Ace, CardSuit.Diamonds),
                    new Card(CardRank.Ace, CardSuit.Hearts),
                    new Card(CardRank.Ace, CardSuit.Spades),
                    new Card(CardRank.Seven, CardSuit.Clubs)
                });
            
            Assert.AreEqual(21, hand.GetValueInt());
        }
    }
}