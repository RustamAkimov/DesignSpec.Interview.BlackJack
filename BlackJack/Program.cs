using System;

namespace BlackJack
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var game = new BlackJackGame();

            var initialCards = game.StartGame();
            
            Console.WriteLine(initialCards.firstCard);
            Console.WriteLine(initialCards.secondCard);

            Console.Write("More?(y/n)");
            while (Console.ReadLine()?.ToLower()=="y")
            {
                Console.WriteLine(game.More());
                Console.Write("More? (y/n) ");
            }
            
            Console.WriteLine("Result is: "+game.Finish());
            
        }
    }
}