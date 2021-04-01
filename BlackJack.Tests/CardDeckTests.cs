using NUnit.Framework;

namespace BlackJack.Tests
{
    public class CardDeckTests
    {
        [Test]
        public void Init52DeskShouldStartWith2Clubs()
        {
            var desk = CardDeck.Generate52Deck(false);

            var firstCardInDesk = desk.GetCard();
            
            Assert.AreEqual(CardRank.Two, firstCardInDesk.Rank);
            Assert.AreEqual(CardSuit.Clubs, firstCardInDesk.Suit);
        }
        
        [Test]
        public void Shuffled52DeskShouldNotStartWith2Clubs()
        {
            var desk = CardDeck.Generate52Deck();

            var firstCardInDesk = desk.GetCard();
            
            Assert.False(CardRank.Two == firstCardInDesk.Rank && firstCardInDesk.Suit == CardSuit.Clubs);
        }
    }
}