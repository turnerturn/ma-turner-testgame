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