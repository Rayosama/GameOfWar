using System;
using System.Collections.Generic;

namespace CardDeck
{
    class Deck
    {
        List<Card> Cards { get; set; } //like an array. It's a container object. We don't get the length, but the count
        public int NumCards { get => Cards.Count; }

        public Deck()
        {
            Cards = new List<Card>();
        }

        public void AddCard(Card newCard)
        {
            Cards.Add(newCard);
        }

        public Card RemoveTopCard()
        {
            Card cardToRemove = Cards[0]; //
            Cards.RemoveAt(0);
            return cardToRemove;
        }
        
        public void PrintDeck()
        {
            foreach(Card c in Cards)
            {
                System.Console.WriteLine(c);
            }
        }

        public void SortDeck() //This will sort the order of the cards when called
        {
            Cards.Sort();
        }

        public void ShuffleDeck() //This shuffles the deck for us
        {
            Random r = new Random();
            for(int counter = 0; counter < 10600; counter++)
            {
                var RandomIndex = r.Next(0, Cards.Count);
                Card cardToRemove2 = Cards[RandomIndex]; //This will create a copy of a random card
                Cards.RemoveAt(RandomIndex);
                Cards.Add(cardToRemove2);
            }
        }
        public void Deal(List<Card> Hand1, List<Card> Hand2) //This assigns the hands to deal the cards to
        {
          

            for (int i = 0; i < 52; i++)  //This method will alternate dealing the cards to our different list. Alternating between odd and even
            {
                if (i % 2 == 0)  //If it's an odd card, it'll go to player 1
                {
                    Hand1.Add(RemoveTopCard());
                }
                else //If it's even, it'll be added to player 2
                {
                    Hand2.Add(RemoveTopCard());
                }

               /* foreach(Card h in Hand1)
                {
                    Console.WriteLine($"Player 1 has: {h}");
                }

                foreach(Card h in Hand2)
                {
                    Console.WriteLine($"Player 2 has: {h}");
                }*/
            }
        }

        public void PlayerTopCard()
        {


                    
        }






        //Attempting to randomize the deck
        
    }
}