using System;
using System.Collections.Generic;

namespace BlackJack
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var game = new BlackJackGame();

            var cards = new List<Card>();
            
            var initialCards = game.StartGame();
            
            Console.WriteLine(initialCards.firstCard);
            Console.WriteLine(initialCards.secondCard);
            
            cards.AddRange(new []{initialCards.firstCard, initialCards.secondCard});

            if(game.CanHaveMore)
                Console.Write("More?(y/n)");
            
            while (game.CanHaveMore && Console.ReadLine()?.ToLower() == "y")
            {
                var card = game.More();
                Console.WriteLine(card);
                cards.Add(card);

                if (game.CanHaveMore)
                    Console.Write("More? (y/n) ");
            }

            Console.WriteLine("Result is: "+game.Finish());
            Console.WriteLine("Poker result is: "+new PokerHand(cards).GetValue()); //Bonus
            
        }
    }
}