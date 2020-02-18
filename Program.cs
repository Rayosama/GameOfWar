using System;
using System.Collections.Generic;
using System.Linq;

namespace CardDeck
{
    class Program
    {
        public static void Main(string[] args)
        {

            //Code for the menu
            bool showMenu = true;
            while (showMenu)
            {
                showMenu = MainMenu();
            }

        }
        private static bool MainMenu() //Method for the menu options
        {
            Console.Clear();
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1) Play War"); //Selecting this one will call out gamePlay method
            Console.WriteLine("2) Exit");

            switch (Console.ReadLine())
            {
                case "1":
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Are you ready for war?!?");
                    Console.WriteLine("Hit enter to continue");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.ReadLine();
                    gamePlay();
                    return true;

                case "2":
                    Console.WriteLine("Bye Felicia");
                    return false;
                default:
                    return true;
            }
        }

        private static void gamePlay() //Method where the gameplay gets executed
        {
            Deck d = new Deck();
            List<Card> Hand1 = new List<Card>();
            List<Card> Hand2 = new List<Card>();
            List<Card> Pile = new List<Card>();

            foreach (CardSuit cs in Enum.GetValues(typeof(CardSuit))) //This will get a list of all the card suits
            {
                foreach (CardValue cv in Enum.GetValues(typeof(CardValue))) //This generates out deck for us
                {
                    d.AddCard(new Card(cs, cv));
                }
            }

            d.ShuffleDeck(); //This calls our method, to shuffle the deck
            d.Deal(Hand1, Hand2); //Deals the DECK to hand1, hand2
            //d.PrintDeck(); //This will simply print the whole deck
            System.Console.WriteLine($"The number of cards in deck is {d.NumCards}");
            //d.SortDeck(); //This sorts the deck
            int numRounds = 0;
            while (Hand1.Count > 0 && Hand2.Count > 0)
            {
                Card hand1Card = Hand1[0];
                Hand1.RemoveAt(0);
                Card hand2Card = Hand2[0];
                Hand2.RemoveAt(0);
                Pile.Add(hand1Card);
                Pile.Add(hand2Card);

                while (hand1Card == hand2Card)
                {
                    hand1Card = Hand1[0];
                    Hand1.RemoveAt(0);
                    Pile.Add(hand1Card);
                    hand2Card = Hand2[0];
                    Hand2.RemoveAt(0);
                    Pile.Add(hand2Card);
                    hand1Card = Hand1[0];
                    Hand1.RemoveAt(0);
                    Pile.Add(hand1Card);
                    hand2Card = Hand2[0];
                    Hand2.RemoveAt(0);
                    Pile.Add(hand2Card);
                }
                if (hand1Card > hand2Card)
                {
                    Hand1.AddRange(Pile);
                    Pile.Clear();

                }
                if (hand2Card > hand1Card)
                {
                    Hand2.AddRange(Pile);
                    Pile.Clear();
                }
                numRounds++;
                Console.WriteLine($"Player 1 Number of cards: {Hand1.Count}");
                Console.WriteLine($"Player 2 Number of cards: {Hand2.Count}");
                Console.WriteLine($"Number of rounds played: {numRounds}");
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Player 1 Number of cards: {Hand1.Count}");
            Console.WriteLine($"Player 2 Number of cards: {Hand2.Count}");
            Console.WriteLine($"Number of rounds: {numRounds}");
            Console.ReadLine(); //This is just to pause the application
        }

        
    }
}
