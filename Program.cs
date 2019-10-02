using System;
using System.Collections.Generic;

namespace Deck_of_Cards
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Deck deck1 = new Deck();
            Player jon = new Player("Jonathan");
            deck1.Shuffle();
            // deck1.Deal();
            // deck1.Deal();
            // deck1.Deal();
            // deck1.Deal();
            // deck1.Deal();
            // deck1.Deal();
            // deck1.Deal();
            // deck1.Deal();
            // deck1.Reset();
            jon.Draw(deck1);
            jon.Draw(deck1);
            jon.Draw(deck1);
            jon.Draw(deck1);
            jon.Draw(deck1);
            jon.DisplayHand();
            jon.Discard();
            jon.DisplayHand();
        }
    }

    public class Card
    {
        public string stringVal;
        public string suit;
        public int val;

        public Card(string stringValInput, string suitInput, int valInput)
        {
            stringVal = stringValInput;
            suit = suitInput;
            val = valInput;
        }
    }
    
    public class Deck
    {
       public List<Card> cards;
       public string[] stringVal = {"Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King"};
       public string[]  suit = {"Clubs", "Spades", "Hearts", "Diamonds"};
       public int[] val = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13};

       public Deck()
       {
            cards = new List<Card>();
            GenerateCards();
       }

        public Card Deal()
        {
            if(cards.Count > 0)
            {
            Card cardRemove = cards[0];
            cards.RemoveAt(0);
            System.Console.WriteLine(cardRemove.val + " of " + cardRemove.suit);
            return cardRemove;
            }
            return null;
        }

        public void GenerateCards()
        {
            for(int i = 0; i < suit.Length; i++)
            {
                for(int j = 0; j < val.Length; j++)
                {
                    cards.Add(new Card(stringVal[j], suit[i], val[j]));
                }
            }
            System.Console.WriteLine("You have created a deck!");
        }

        public void Reset()
        {
            cards.Clear();
            GenerateCards();
            System.Console.WriteLine("Your deck has been reset.");
        }

        public void Shuffle()
        {
            List<Card> ShuffledCards = new List<Card>();
            Random rand = new Random();
            while(cards.Count > 0)
            {
                Card randCard = cards[rand.Next(cards.Count)];
                ShuffledCards.Add(randCard);
                cards.Remove(randCard);
            }
            cards = ShuffledCards;
            System.Console.WriteLine("The deck has been shuffled.");
        }

    }

    public class Player
    {
        public string name;
        public List<Card> hand;

        public Player(string nameInput)
        {
            name = nameInput;
            hand = new List<Card>();
        }

        public Card Draw(Deck deck)
        {
            Card card = deck.Deal();
            this.hand.Add(card);
            return card;
        }

        public void DisplayHand()
        {
            for(int i = 0; i < hand.Count; i++)
            {
                Console.WriteLine(hand[i].val + " of " + hand[i].suit);
            }
        }

        public Card Discard()
        {
            if(this.hand != null)
            {
            Random rand = new Random();
            int idx = rand.Next(this.hand.Count);
            Card cardRemove = hand[idx];
            this.hand.Remove(cardRemove);
            System.Console.WriteLine(cardRemove.val + " of " + cardRemove.suit + " has been removed.");
            return cardRemove;
            }
            return null;
        }
    }
}
