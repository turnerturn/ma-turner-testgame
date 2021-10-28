using System;

namespace BlackJack
{

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
    /**
     * Each deck will contain 52 cards.
     */
    class Deck
    {
        int[] cards;
        public Hand()
        {
            //TODO init the deck of cards array.
        }

        private int[] initDeckOfCards()
        {
            //52 cards in a deck
            int[] cards = new int[52];
            //TODO populate array for deck of cards. This will represent the project's "GRID BASED" game.
            //Hint:  A black jack face cards will use a value of 10.
            //Hint:  Ace is a value of 1 or 11.  Lets assign it initial value of 11.  Dealer will need to reassign value to 1 when appropriate.

            return 
        }
    }
        /**
         * A hand will consist of 2 to many cards. Each BlackJack player will be dealt one hand.
        */
    class Hand
    {
        int[] cards;
        public Hand()
        {
            //TODO init cards array.
        }

        //TODO provide getter method.  
        //TODO Implement method to AddCard.
    }

    class BlackJackGame
    {
        //Dealer's hand to be used for each game.  
        //First card of dealer's hand will be visible to player.
        private Hand dealerHand;

        private Hand[] playerHands;


        public BlackJackGame()
        {
        }
        //TODO getters and setters
    }
    static class Dealer
    {

        public static BlackJackGame InitBlackJackGame()
        {
            //TODO implement the stuffs
            return new BlackJackGame();
        }

        public static BlackJackGame Deal(BlackJackGame game)
        {

            return game;
        }
        public static Boolean IsWinner(Hand hand)
        {
            return false;
        }
        public static Boolean IsBust(Hand hand)
        {
            //total sum of hand's cards.  return true if hand's sum is > 21.
            return true;
        }
        /**
        * Shuffle the given array of cards.
        * Sorts the given array of ints in random order and returns the sorted array.
        */
        public static int[] ShuffleCards(int[] cards)
        {
            Random rand = new Random();

            // For each spot in the array, picka random item to swap into that spot.
            for (int i = 0; i < cards.Length - 1; i++)
            {
                int j = rand.Next(i, cards.Length);
                //We need temp value to store current value at index i.
                int temp = cards[i];
                //Replace value at index i with value from index j.
                cards[i] = cards[j];
                //Replace value at index j with value that was stored at index i.
                cards[j] = temp;
            }

            return cards;
        }
    }
}
